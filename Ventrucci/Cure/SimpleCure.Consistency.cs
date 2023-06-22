using OP22_global_outbreak_Csharp.Ventrucci.ConsoleLogger;

namespace OOP22_global_outbreak_Csharp.Ventrucci.Cure
{
    public partial class SimpleCure : ICure
    {
        private bool ConsistCheck()
        {
            if (_priorities.Count == 0)
            {
                ConsoleLogger.Logger.Log(LogLevel.Warning, "Priority list can't be empty");
                return false;
            }
            if (_contributions.Count == 0)
            {
                ConsoleLogger.Logger.Log(LogLevel.Warning, "Regions list can't be empty");
                // return false;
            }
            if (_priorities.Where(el => el.Priority == _currentPriority).Count() != 1)
            {
                ConsoleLogger.Logger.Log(LogLevel.Warning, "Invalid current prioriry: current priority '" + _currentPriority + "' is not found in the priorities '" + _priorities + "'");
                return false;
            }
            if (_necessaryBudget < _researchBudget)
            {
                ConsoleLogger.Logger.Log(LogLevel.Warning, "Research budget '" + _researchBudget + "' must be lower than necessary budget '" + _necessaryBudget + "'");
                return false;
            }

            return CheckIfPositive(_dailyBudget, "dailyBudget")
                    && CheckIfPositive(_numberOfMajorContributors, "numberOfMajorContributors")
                    && CheckIfPositive(_researchersEfficiency, "researchersEfficiency")
                    && CheckIfPositive(_necessaryBudget, "necessaryBudget")
                    && CheckIfPositive(_researchBudget, "researchBudget")
                    && CheckIfPositive(_currentPriority, "currentPriority")
                    && CheckIfPositive(_daysBeforeStartResearch, "daysBeforeStartResearch");
        }

        private static bool CheckIfPositive(float number, string name)
        {
            if (number < 0)
            {
                ConsoleLogger.Logger.Log(LogLevel.Warning, "Value " + name + " can't be negative");
                return false;
            }
            return true;
        }

    }
}
