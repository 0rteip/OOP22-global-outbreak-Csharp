using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OOP22_global_outbreak_Csharp.Ventrucci.ConsoleLogger;
using OOP22_global_outbreak_Csharp.Ventrucci.Cure.Priority;
using OOP22_global_outbreak_Csharp.Ventrucci.Cure.Priority.Reader;
using carabini.region;
using OP22_global_outbreak_Csharp.Ventrucci.ConsoleLogger;

namespace OOP22_global_outbreak_Csharp.Ventrucci.Cure.Reader
{
    public class SimpleCureReader : ISimpleCureReader
    {
        private readonly string FILE_PATH = Path.Combine(Environment.CurrentDirectory, "cure.json");

        public SimpleCure GetSimpleCure(List<IRegion> regions)
        {
            List<IPriority> priorities = new CurePriorityReader().GetPriorities();
            SimpleCure cure;
            try
            {
                SimpleCure.Builder cureBuilder = new(regions, priorities);

                string jsonContent = File.ReadAllText(FILE_PATH, Encoding.UTF8);
                JObject jsonObject = JsonConvert.DeserializeObject<JObject>(jsonContent) ?? new JObject();

                foreach (KeyValuePair<string, JToken?> entry in jsonObject)
                {
                    string key = entry.Key;
                    JToken value = entry.Value!;

                    switch (key)
                    {
                        case "dailyBudget":
                            cureBuilder.SetDailyBudget(value.Value<float>());
                            break;
                        case "numberOfMajorContributors":
                            cureBuilder.SetNumberOfMajorContributors(value.Value<int>());
                            break;
                        case "researchersEfficiency":
                            cureBuilder.SetResearchersEfficiency(value.Value<float>());
                            break;
                        case "necessaryBudget":
                            cureBuilder.SetNecessaryBudget(value.Value<float>());
                            break;
                        case "researchBudget":
                            cureBuilder.SetResearchBudget(value.Value<float>());
                            break;
                        case "currentPriority":
                            cureBuilder.SetCurrentPriority(value.Value<int>());
                            break;
                        case "daysBeforeStartResearch":
                            cureBuilder.SetDaysBeforeStartResearch(value.Value<int>());
                            break;
                        case "rilevantProgress":
                            if (value is JArray progs)
                            {
                                HashSet<int> ints = new();
                                foreach (JToken numberNode in progs)
                                {
                                    ints.Add(numberNode.Value<int>());
                                }
                                cureBuilder.SetRilevantProgress(ints);
                            }
                            break;
                        default:
                            Logger.Log("Value '" + value + "' not recognized");
                            break;
                    }
                }

                cure = cureBuilder.Build();
            }
            catch (IOException e)
            {
                Logger.Log(LogLevel.Warning, "Unable to read '" + FILE_PATH + "':" + e);
                cure = new SimpleCure.Builder(regions, priorities).Build();
            }
            catch (FormatException e)
            {
                Logger.Log(LogLevel.Warning, "File '" + FILE_PATH + "' format is incorect:" + e);
                cure = new SimpleCure.Builder(regions, priorities).Build();
            }
            return cure;
        }
    }
}
