using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using farabegoli.disease;

namespace farabegoli.diseasereader
{
    /**
     * Classe che legge il file delle malattie.
     */
    public class DiseaseReaderImpl : IDiseaseReader
    {
        private static readonly string DISEASES_FILE_PATH = "DiseaseData.json";


        private List<DiseaseData> diseases = new List<DiseaseData>();


        /**
         * Costruttore.
         * 
         * Legge il file e crea gli oggetti DiseaseData.
         */
        public DiseaseReaderImpl()
        {
            try
            {
                JsonDocument document = JsonDocument.Parse(File.ReadAllText(DISEASES_FILE_PATH));

                foreach (JsonElement element in document.RootElement.EnumerateArray())
                {
                    DiseaseData diseaseData = new DiseaseData();

                    foreach (JsonProperty property in element.EnumerateObject())
                    {
                        switch (property.Name)
                        {
                            case "type":
                                diseaseData.Type = property.Value.GetString();
                                break;
                            case "infectivity":
                                 diseaseData.Infectivity = property.Value.GetSingle();
                                break;
                            case "lethality":
                                diseaseData.Lethality = property.Value.GetSingle();
                                break;
                            case "airInfectivity":
                                diseaseData.AirInfectivity = property.Value.GetSingle();
                                break;
                            case "landInfectivity":
                                diseaseData.LandInfectivity = property.Value.GetSingle();
                                break;
                            case "seaInfectivity":
                                diseaseData.SeaInfectivity = property.Value.GetSingle();
                                break;
                            case "heatInfectivity":
                                diseaseData.HeatInfectivity = property.Value.GetSingle();
                                break;
                            case "coldInfectivity":
                                diseaseData.ColdInfectivity = property.Value.GetSingle();
                                break;
                            case "cureResistance":
                                diseaseData.CureResistance = property.Value.GetSingle();
                                break;
                            case "humidityInfectivity":
                                diseaseData.HumidityInfectivity = property.Value.GetSingle();
                                break;
                            case "aridityInfectivity":
                                diseaseData.AridityInfectivity = property.Value.GetSingle();
                                break;
                            case "povertyInfectivity":
                                diseaseData.PovertyInfectivity = property.Value.GetSingle();
                                break;
                            default:
                                Console.WriteLine($"Stringa non riconosciuta nel file {DISEASES_FILE_PATH}");
                                break;
                        }
                    }

                    diseases.Add(diseaseData);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Errore durante la lettura o la deserializzazione del contenuto JSON nel file {DISEASES_FILE_PATH}: {e.Message}");
            }
        }

        /**
         * @return
         *         una copia della lista di DiseaseData.
         */
        public List<DiseaseData> GetDiseases()
        {
            return new List<DiseaseData>(diseases);
        }
    }
}
