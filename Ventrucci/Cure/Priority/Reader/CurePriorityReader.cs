using System.Text;
using Newtonsoft.Json.Linq;
using OOP22_global_outbreak_Csharp.Ventrucci.ConsoleLogger;
using OP22_global_outbreak_Csharp.Ventrucci.ConsoleLogger;

namespace OOP22_global_outbreak_Csharp.Ventrucci.Cure.Priority.Reader
{
    /// <summary>
    /// A Cure Priority reader based on priorities.json.
    /// </summary>
    public class CurePriorityReader : IPriorityReader
    {
        private readonly string FILE_PATH = Path.Combine("priorities.json");

        public List<IPriority> GetPriorities()
        {
            List<IPriority> _priorities = new();

            try
            {
                CurePriority.Builder priorityBuilder = new();
                string jsonString = File.ReadAllText(FILE_PATH, Encoding.UTF8);
                JArray jsonArray = JArray.Parse(jsonString);

                foreach (JObject jsonObject in jsonArray.Cast<JObject>())
                {
                    foreach (var kvp in jsonObject)
                    {
                        string key = kvp.Key;
                        JToken value = kvp.Value!;

                        switch (key)
                        {
                            case "priority":
                                priorityBuilder.SetPriority(value.Value<int>());
                                break;
                            case "description":
                                priorityBuilder.SetDescription(value.Value<string>()!);
                                break;
                            case "resourcesPercentage":
                                priorityBuilder.SetResourcesPercentage(value.Value<float>());
                                break;
                            case "detectionRate":
                                priorityBuilder.SetDetectionRate(value.Value<float>());
                                break;
                            default:
                                Logger.Log(LogLevel.Warning, "Value '" + key + "' not recognized");
                                break;
                        }
                    }

                    _priorities.Add(priorityBuilder.Build());
                }
            }
            catch (IOException e)
            {
                Logger.Log(LogLevel.Warning, "Unable to read " + FILE_PATH + ":" + e);
            }
            catch (FormatException e)
            {
                Logger.Log(LogLevel.Warning, "File '" + FILE_PATH + "' format is incorect:" + e);
            }
            if (_priorities.Count == 0)
            {
                _priorities.Add(new CurePriority.Builder().Build());
            }
            return _priorities;
        }
    }
}
