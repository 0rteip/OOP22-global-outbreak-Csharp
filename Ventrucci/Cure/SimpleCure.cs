using OOP22_global_outbreak_Csharp.Ventrucci.Cure.Priority;
using carabini.region;
using OOP22_global_outbreak_Csharp.Ventrucci.ConsoleLogger;

namespace OOP22_global_outbreak_Csharp.Ventrucci.Cure;
public partial class SimpleCure : ICure
{
    private Dictionary<IRegion, float> _contributions;
    private readonly HashSet<int> _rilevantProgress;
    private readonly List<IPriority> _priorities;
    private readonly float _researchersEfficiency;
    private readonly float _dailyBudget;
    private readonly int _numberOfMajorContributors;
    private readonly float _necessaryBudget;
    private float _researchBudget;
    private int _daysBeforeStartResearch;
    private int _currentPriority;
    private bool _isStarted;
    private bool _isComplete;
    private Action<int>? _action;
    private bool _isCompleted = false;

    private SimpleCure(float dailyBudget, int numberOfMajorContributors, Dictionary<IRegion, float> contributions,
            float researchersEfficiency, List<IPriority> priorities, float necessaryBudget, float researchBudget,
            int currentPriority, int daysBeforeStartResearch, HashSet<int> rilevantProgress)
    {
        _dailyBudget = dailyBudget;
        _numberOfMajorContributors = numberOfMajorContributors;
        _contributions = contributions;
        _researchersEfficiency = researchersEfficiency;
        _priorities = priorities;
        _necessaryBudget = necessaryBudget;
        _researchBudget = researchBudget;
        _currentPriority = currentPriority;
        _daysBeforeStartResearch = daysBeforeStartResearch;
        _rilevantProgress = rilevantProgress;
    }

    public ICureData GlobalStatus => GetGlobalStatus();

    private ICureData GetGlobalStatus()
    {
        return new CureData
        {
            Progress = CureProgress(),
            RemainingDays = CalculateRemainingDays(),
            MajorContributors = GetMajorContributors(),
            Priority = _priorities[_currentPriority]
        };
    }


    private int? CalculateRemainingDays()
    {
        float dailyInvestment = _contributions
            .Where(el => el.Key.GetCureStatus() == RegionCureStatus.STARTED)
            .Sum(el => DailyRegionContribution(el.Key));

        if (dailyInvestment != 0)
        {
            return (int)Math.Round((_necessaryBudget - _researchBudget) / dailyInvestment);
        }
        else
        {
            return null;
        }
    }

    private List<IRegion>? GetMajorContributors()
    {
        if (_isStarted)
        {
            return _contributions
                .OrderByDescending(el => el.Value)
                .Select(el => el.Key)
                .Take(_numberOfMajorContributors)
                .ToList();
        }
        else
        {
            return new List<IRegion>();
        }
    }

    public bool IsCompleted => _isCompleted;

    public bool IsConsistent => ConsistCheck();

    public void AddAction(Action<int> action)
    {
    }

    public void IncreaseResearchDifficulty(float changeFactor)
    {
    }

    public void ReduceResearchProgress(float changeFactor)
    {
    }

    public void Research()
    {
        if (_isStarted)
        {
            _contributions = _contributions
                    .Where(c => c.Key.GetCureStatus() == RegionCureStatus.STARTED)
                    .ToDictionary(entry => entry.Key, entry => entry.Value + DailyRegionContribution(entry.Key));
            UpdateResearchBudget();
            if (HighMortalityRateRegions().Any())
            {
                IncreasePriority();
            }
        }
        else
        {
            if (NumberOfRegionsTahtDiscoveredDisease() > 0 && _daysBeforeStartResearch == 0)
            {
                Logger.Log("Start cure");
                _isStarted = true;
                IncreasePriority();
                _contributions.Where(el => el.Key.GetDeathByVirus() != el.Key.GetPopTot())
                        .ToList()
                        .ForEach(el => el.Key.SetCureStatus(RegionCureStatus.STARTED));
            }
            else
            {
                if (HighMortalityRateRegions().Any())
                {
                    _daysBeforeStartResearch--;
                    HighMortalityRateRegions()
                            .Where(el => el.Key.GetDeathByVirus() != el.Key.GetPopTot())
                            .ToList()
                            .ForEach(el => el.Key.SetCureStatus(RegionCureStatus.DISCOVERED));
                }
            }
            if (CureProgress() >= 100)
            {
                _isComplete = true;
            }
        }
    }

    private int CureProgress()
    {
        var progress = (int)Math.Round((double)(_researchBudget / _necessaryBudget * 100));
        if (progress >= 100)
        {
            _researchBudget = _necessaryBudget;
            return 100;
        }
        return progress;
    }

    private int NumberOfRegionsTahtDiscoveredDisease() => _contributions
            .Where(c => c.Key.GetCureStatus()
            .Equals(RegionCureStatus.DISCOVERED))
            .Count();

    private float DailyRegionContribution(IRegion region) => (1 - (region.GetDeathByVirus() / region.GetPopTot()))
                * region.GetFacilities()
                * this._researchersEfficiency
                * _priorities[_currentPriority].ResourcesPercentage
                * _dailyBudget;

    private void UpdateResearchBudget() => _researchBudget = _contributions
            .Values.Min();

    private IEnumerable<KeyValuePair<IRegion, float>> HighMortalityRateRegions() => _contributions
            .Where(el => el.Key.GetDeathByVirus() / el.Key.GetPopTot() > _priorities[_currentPriority].DetectionRate);

    private void IncreasePriority()
    {
        var nextPriority = _priorities.FirstOrDefault(el => el.Priority == _currentPriority + 1);
        if (nextPriority != null)
        {
            _currentPriority = nextPriority.Priority;
            Logger.Log("Research priority: " + _priorities[_currentPriority]);
        }

    }
}
