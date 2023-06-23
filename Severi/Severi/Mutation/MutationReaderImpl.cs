using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Severi.Mutation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Severi.Mutation
{
    internal class MutationReaderImpl : MutationReader

        {
        private readonly MutationData _mutationData;

        public MutationReaderImpl(MutationData mutationData)
            {
            this._mutationData = mutationData;
            }

            public void ReadMutation()
            {

            string currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string filePath = Path.Combine(currentDirectory, "Mutation/Mutation.json");
            string fileContent = File.ReadAllText(filePath);

            try
            {
                JArray jsonArray = JArray.Parse(fileContent);
                foreach (JObject jsonObject in jsonArray)
                {

                    int cost = jsonObject.Value<int>("cost");
                    string name = jsonObject.Value<string>("name");
                    float increase = jsonObject.Value<float>("increase");
                    string typestring = jsonObject.Value<string>("type");
                    TypeMutation type = Enum.Parse<TypeMutation>(typestring);
                    string description = jsonObject.Value<string>("description");
                    _mutationData.LoadMutationFromJson(cost, name, increase,type,description);

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la lettura del file JSON: {ex.Message}");
            }
        }
    }
    

}
