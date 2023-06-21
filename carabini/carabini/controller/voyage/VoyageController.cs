using carabini.voyages;
using Newtonsoft.Json;

namespace voyageController
{
    public class VoyageController
    {
        readonly IVoyages _voyages;
        public VoyageController() 
        {
            Dictionary<string, Tuple<int, int>> sizeAndNameOfMeans = new();
            StreamReader r = new("C:\\Users\\luca0\\OneDrive\\Desktop\\carabini\\carabini\\configFiles\\ConfigMeans.json");
            string jsonString = r.ReadToEnd();
            List<VoyageRead>? m = JsonConvert.DeserializeObject<List<VoyageRead>>(jsonString);
            m?.ForEach(r => { sizeAndNameOfMeans.Add(r.Type, new(r.Num, r.Passengers)); });
            this._voyages = new VoyagesImpl(sizeAndNameOfMeans);
        }
        public IVoyages CreateVoyage()
        {
            return this._voyages;
        }
    }
}
