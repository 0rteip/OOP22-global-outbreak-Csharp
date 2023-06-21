using carabini.region;
using Newtonsoft.Json;
namespace region
{
    public class RegionController
    {
        readonly List<IRegion> _regions;
        public RegionController ()
        {
            this._regions = new();
            StreamReader r = new("C:\\Users\\luca0\\OneDrive\\Desktop\\carabini\\carabini\\configFiles\\configRegion.json");
            string jsonString = r.ReadToEnd();
            List<ReadRegion>? m = JsonConvert.DeserializeObject<List<ReadRegion>>(jsonString);
            m?.ForEach(r => { _regions.Add(new RegionImpl(r.PopTot, r.Nome, CreateMap(r), r.Urban, r.Poor, r.Colore, r.Facilities, r.Hot, r.Humid, r.CloseMeans)); });
        }
        private static Dictionary<string, Tuple<int, List<string>?>> CreateMap(ReadRegion r)
        {
            Dictionary<string, Tuple<int, List<string>?>> means = new();
            if (r.Confini != null)
            {
                means.Add("terra", new(1, r.Confini));
            }
            if(r.Aereoporti > 0)
            {
                means.Add("aereoporti", new(r.Aereoporti, new()));
            }
            if (r.Porti > 0)
            {
                means.Add("porti", new(r.Porti, new()));
            }
            return means;
        }
        public List<IRegion> GetRegions()
        {
            return new(_regions);
        }
    }
}
