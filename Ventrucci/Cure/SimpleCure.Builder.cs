using OOP22_global_outbreak_Csharp.Ventrucci.Cure.Priority;
using OOP22_global_outbreak_Csharp.Ventrucci.Region;

namespace OOP22_global_outbreak_Csharp.Ventrucci.Cure;

/// <summary>
/// Builder for SimpleCure.
/// </summary>
public partial class SimpleCure
{
    /// <summary>
    /// A simpleCureBuilder.
    /// </summary>
    public class Builder
    {
        private const float DAILY_BUDGET = 1_146.56f;
        private const int NUMBER_OF_MAJOR_CONTRIBUTORS = 3;
        private const float RESEARCHERS_EFFICIENCY = 1;
        private const float NECESSARY_BUDGET = 25_000_000;
        private const float RESEARCH_BUDGET = 0;
        private const int CURRENT_PRIORITY = 0;
        private const int DAYS_BEFORE_START_RESEARCH = 10;
        private static readonly HashSet<int> RILEVANT_PROGRESS = new();

        private float dailyBudget = DAILY_BUDGET;
        private int numberOfMajorContributors = NUMBER_OF_MAJOR_CONTRIBUTORS;
        private float researchersEfficiency = RESEARCHERS_EFFICIENCY;
        private float necessaryBudget = NECESSARY_BUDGET;
        private float researchBudget = RESEARCH_BUDGET;
        private int currentPriority = CURRENT_PRIORITY;
        private int daysBeforeStartResearch = DAYS_BEFORE_START_RESEARCH;
        private HashSet<int> rilevantProgress = RILEVANT_PROGRESS;
        private readonly List<IPriority> priorities;
        private readonly Dictionary<IRegion, float> contributions = new();
        private bool consumed;

        /// <summary>
        /// Based on IRegion and IPriority.
        /// </summary>
        /// <param name="regions"></param>
        /// <param name="priorities"></param>
        public Builder(List<IRegion> regions, List<IPriority> priorities)
        {
            if (regions.Count > 0)
            {
                regions.ForEach(el => contributions[el] = 0);
            }
            this.priorities = new List<IPriority>(priorities);
        }

        /// <summary>
        /// Set dailyBudget.
        /// </summary>
        /// <param name="dailyBudget"></param>
        /// <returns>this builder for Builder pattern.</returns>
        public Builder SetDailyBudget(float dailyBudget)
        {
            this.dailyBudget = dailyBudget;
            return this;
        }

        /// <summary>
        /// Set numberOfMajorContributors.
        /// </summary>
        /// <param name="numberOfMajorContributors"></param>
        /// <returns>this builder for Builder pattern.</returns>
        public Builder SetNumberOfMajorContributors(int numberOfMajorContributors)
        {
            this.numberOfMajorContributors = numberOfMajorContributors;
            return this;
        }

        /// <summary>
        /// Set researchersEfficiency.
        /// </summary>
        /// <param name="researchersEfficiency"></param>
        /// <returns>this builder for Builder pattern.</returns>
        public Builder SetResearchersEfficiency(float researchersEfficiency)
        {
            this.researchersEfficiency = researchersEfficiency;
            return this;
        }

        /// <summary>
        /// Set necessaryBudget.
        /// </summary>
        /// <param name="necessaryBudget"></param>
        /// <returns>this builder for Builder pattern.</returns>
        public Builder SetNecessaryBudget(float necessaryBudget)
        {
            this.necessaryBudget = necessaryBudget;
            return this;
        }

        /// <summary>
        /// Set researchBudget.
        /// </summary>
        /// <param name="researchBudget"></param>
        /// <returns>this builder for Builder pattern.</returns>
        public Builder SetResearchBudget(float researchBudget)
        {
            this.researchBudget = researchBudget;
            return this;
        }

        /// <summary>
        /// Set currentPriority.
        /// </summary>
        /// <param name="currentPriority"></param>
        /// <returns>this builder for Builder pattern.</returns>
        public Builder SetCurrentPriority(int currentPriority)
        {
            this.currentPriority = currentPriority;
            return this;
        }

        /// <summary>
        /// Set daysBeforeStartResearch.
        /// </summary>
        /// <param name="daysBeforeStartResearch"></param>
        /// <returns>this builder for Builder pattern.</returns>
        public Builder SetDaysBeforeStartResearch(int daysBeforeStartResearch)
        {
            this.daysBeforeStartResearch = daysBeforeStartResearch;
            return this;
        }

        /// <summary>
        /// Set rilevantProgress.
        /// </summary>
        /// <param name="rilevantProgress"></param>
        /// <returns>this builder for Builder pattern.</returns>
        public Builder SetRilevantProgress(HashSet<int> rilevantProgress)
        {
            this.rilevantProgress = new HashSet<int>(rilevantProgress);
            return this;
        }

        /// <summary>
        /// Build a SimpleCure.
        /// </summary>
        /// <returns>SimpleCure instance.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public SimpleCure Build()
        {
            if (consumed)
            {
                throw new InvalidOperationException("The builder can only be used once");
            }
            consumed = true;

            return new SimpleCure(dailyBudget, numberOfMajorContributors, contributions, researchersEfficiency,
                priorities, necessaryBudget, researchBudget, currentPriority, daysBeforeStartResearch,
                rilevantProgress);
        }
    }
}