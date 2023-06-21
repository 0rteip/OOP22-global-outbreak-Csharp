using OOP22_global_outbreak_Csharp.Ventrucci.Cure.Priority;
using OOP22_global_outbreak_Csharp.Ventrucci.Region;

namespace OOP22_global_outbreak_Csharp.Ventrucci.Cure;
public partial class SimpleCure : ICure
{
    private readonly Dictionary<IRegion, float> _contributions;
    private readonly HashSet<int> _rilevantProgress;
    private readonly List<IPriority> _priorities;
    private readonly float _researchersEfficiency;
    private readonly float _dailyBudget;
    private readonly int _numberOfMajorContributors;
    private float _necessaryBudget;
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

    public ICureData GlobalStatus => throw new NotImplementedException();

    public bool IsCompleted => _isCompleted;

    public bool IsConsistent => ConsistCheck();

    public void AddAction(Action<int> action)
    {
        throw new NotImplementedException();
    }

    public void IncreaseResearchDifficulty(float changeFactor)
    {
        throw new NotImplementedException();
    }

    public void ReduceResearchProgress(float changeFactor)
    {
        throw new NotImplementedException();
    }

    public void Research()
    {
        _isCompleted = true;
    }
}
