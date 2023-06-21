using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OOP22_global_outbreak_Csharp.Ventrucci.ConsoleLogger;
using OOP22_global_outbreak_Csharp.Ventrucci.Cure.Priority;
using OOP22_global_outbreak_Csharp.Ventrucci.Cure.Priority.Reader;
using OOP22_global_outbreak_Csharp.Ventrucci.Region;
using OP22_global_outbreak_Csharp.Ventrucci.ConsoleLogger;

namespace OOP22_global_outbreak_Csharp.Ventrucci.Cure.Reader
{
    public class SimpleCureReader : ISimpleCureReader
    {
        private const string FILE_PATH = "Ventrucci/Resources/cure.json";

        public SimpleCure GetSimpleCure(List<IRegion> regions)
        {
            List<IPriority> priorities = new CurePriorityReader().GetPriorities();
            SimpleCure cure;
            try
            {
                SimpleCure.Builder cureBuilder = new SimpleCure.Builder(regions, priorities);

                string jsonContent = File.ReadAllText(FILE_PATH, Encoding.UTF8);
                JObject jsonObject = JsonConvert.DeserializeObject<JObject>(jsonContent);

                foreach (KeyValuePair<string, JToken> entry in jsonObject)
                {
                    string key = entry.Key;
                    JToken value = entry.Value;

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
                                HashSet<int> ints = new HashSet<int>();
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
                Logger.Log(LogLevel.Warning, "Unable to read " + FILE_PATH + ":" + e);
                cure = new SimpleCure.Builder(regions, priorities).Build();
            }
            return cure;
        }
    }
}
