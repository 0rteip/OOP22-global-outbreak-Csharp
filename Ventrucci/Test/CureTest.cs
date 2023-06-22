using carabini.region;
using NUnit.Framework;
using OOP22_global_outbreak_Csharp.Ventrucci.Cure;
using OOP22_global_outbreak_Csharp.Ventrucci.Cure.Priority;

namespace OOP22_global_outbreak_Csharp.Ventrucci.Test;
[TestFixture]
class CureTest
{
    private SimpleCure.Builder? _cureBuilder;

    [SetUp]
    public void SetUp()
    {
        float resPerc = 0.3f;
        List<IPriority> prios = new()
        {
            new CurePriority.Builder()
            .SetResourcesPercentage(resPerc)
            .Build()
        };
        List<IRegion> regions = GetRegions();
        _cureBuilder = new SimpleCure.Builder(regions, prios);
    }

    [Test]
    public void TestCureData()
    {
        int currentPriority = 0;
        float dailyBudget = 1_000.5f;
        int daysBeforeStartResearch = 5;
        float necessaryBudget = 20_000_000;
        int numberOfMajorContributors = 0;
        float researchBudget = 10;
        float researchersEfficiency = 0.4f;
        if (_cureBuilder != null)
        {
            ICure cure = _cureBuilder
                    .SetCurrentPriority(currentPriority)
                    .SetDailyBudget(dailyBudget)
                    .SetDaysBeforeStartResearch(daysBeforeStartResearch)
                    .SetNecessaryBudget(necessaryBudget)
                    .SetNumberOfMajorContributors(numberOfMajorContributors)
                    .SetResearchBudget(researchBudget)
                    .SetResearchersEfficiency(researchersEfficiency)
                    .Build();

            if (cure.GlobalStatus.MajorContributors != null)
            {
                Assert.IsEmpty(cure.GlobalStatus.MajorContributors);
            }
            Assert.Null(cure.GlobalStatus.RemainingDays);

            foreach (var _ in Enumerable.Range(0, daysBeforeStartResearch + 1))
            {
                cure.Research();
            }
            if (cure.GlobalStatus.MajorContributors != null)
            {
                Assert.That(cure.GlobalStatus.MajorContributors.Count, Is.EqualTo(numberOfMajorContributors));
            }
            Assert.Null(cure.GlobalStatus.RemainingDays);
        }
    }

    [Test]
    public void TestSingleUseCureBuilder()
    {
        if (_cureBuilder != null)
        {
            Assert.True(_cureBuilder.Build().IsConsistent);
            Assert.That(() => _cureBuilder.Build(), Throws.TypeOf<InvalidOperationException>());
        }
    }

    /**
     * Test if Simple CUre can be initialized with empty list.
     */
    [Test]
    public void TestIncosistentWithEmptyList()
    {
        if (_cureBuilder != null)
        {
            // Regions and Prioritys can't be empty
            Assert.False(new SimpleCure.Builder(new(), new())
                    .Build()
                    .IsConsistent);
        }
    }

    [Test]
    public void TestIncosistentWithInvalidPriority()
    {
        if (_cureBuilder != null)
        {
            int invalidPriority = 1;
            // Priority must be contained in the prioritys of the cure
            Assert.False(_cureBuilder
                    .SetCurrentPriority(invalidPriority)
                    .Build()
                    .IsConsistent);
        }
    }

    [Test]
    public void TestIncosistentWithNegativiValue()
    {
        if (_cureBuilder != null)
        {
            float invalidDailyBudget = -12_000f;
            // All value must be positive (one test is sufficient)
            Assert.False(_cureBuilder
                    .SetDailyBudget(invalidDailyBudget)
                    .Build()
                    .IsConsistent);
        }
    }

    [Test]
    public void TestIncosistentWithHIgherResearchBudget()
    {
        if (_cureBuilder != null)
        {
            float higherValue = 100_000;
            float lowerValue = 50_000;
            // Necessary budget mjst be higher than research budget
            Assert.False(_cureBuilder
                    .SetNecessaryBudget(lowerValue)
                    .SetResearchBudget(higherValue)
                    .Build()
                    .IsConsistent);
        }
    }

    private static List<IRegion> GetRegions()
    {
        List<IRegion> r = new();
        return r;
    }
}