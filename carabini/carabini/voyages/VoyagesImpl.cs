using carabini.region;

namespace carabini.voyages
{
    public class VoyagesImpl : IVoyages
    {
        private readonly Dictionary<string, Tuple<int, int>> _sizeAndNameOfMeans;
        private readonly Random _rand = new();

        /**
         * 
         * @param sizeAndNameOfMeans
         */
        public VoyagesImpl(Dictionary<string, Tuple<int, int>> sizeAndNameOfMeans)
        {
            _sizeAndNameOfMeans = new Dictionary<string, Tuple<int, int>>(sizeAndNameOfMeans);
        }

        public List<IVoyage> ExtractVoyages(List<IRegion> regions, Dictionary<string, float> pot)
        {
            List<IVoyage> voyages = new();
            foreach (var elem in _sizeAndNameOfMeans)
            {
                List<IRegion> newRegions = regions.Where(region => CheckIfMeansAreOpen(region.GetTrasmissionMeans(), elem.Key)).ToList();
                if (newRegions.Count > 1)
                {
                    var tuple = elem.Value;
                    for (int i = 0; i < tuple.Item1; i++)
                    {
                        Tuple<IRegion, IRegion>? partDest = ExtractRegion(newRegions, elem.Key);
                        if (partDest != null)
                        {
                            IRegion part = partDest.Item1;
                            float prob = 0;
                            if (part.CalcPercInfected() > 0)
                            {
                                prob = part.CalcPercInfected() + pot[elem.Key];
                            }
                            IVoyage voyage = new VoyageImpl(elem.Key, partDest.Item1.GetColor(),
                                    partDest.Item2.GetColor(),
                                    NumInfected(prob, tuple.Item2));
                            voyages.Add(voyage);
                        }
                    }
                }
            }
            return voyages;
        }
        private Tuple<IRegion, IRegion>? ExtractRegion(List<IRegion> newRegions, string type)
        {
            IRegion region = newRegions[_rand.Next(0, newRegions.Count)];
            List<IRegion> efectieRegions = new(newRegions);
            efectieRegions.Remove(region);
            
            Tuple<IRegion, IRegion>? tuple = null;
            switch (type)
            {
                case "terra":
                    efectieRegions = FindRegionsByName(newRegions, region.GetTrasmissionMeans()
                            .Where(k => k.GetMeans().Equals(type))
                            .First()
                            .GetReachableStates());
                    break;
                default:
                    break;
            }
            if (efectieRegions != null)
            {
                IRegion dest = efectieRegions[_rand.Next(0, efectieRegions.Count)];
                tuple = new Tuple<IRegion, IRegion>(region, dest);
                return tuple;
            }
            return tuple;
        }
        private static List<IRegion> FindRegionsByName(List<IRegion> regions, List<string>? nameRegions)
        {
            List<IRegion> rs = new();
            if (nameRegions != null)
            {
                regions.ForEach(k =>
                {
                    nameRegions.ForEach(s =>
                    {
                        if (k.GetName().Equals(s))
                        {
                            rs.Add(k);
                        }
                    });
                });
            }
            return rs;
        }
        private static bool CheckIfMeansAreOpen(List<ITransmissionMean> list, string means)
        {
            long open = list.Where(k => k.GetMeans().Equals(means) && k.GetState().Equals(MeansState.OPEN)).Count();
            return open > 0;
        }

        private long NumInfected(float prob, int size)
        {
            long prod = (int)Math.Round(size * prob);
            if (prod > size)
            {
                // logger.warn("too many seatsI'll fill the plane");
                return size;
            }
            else if (_rand.Next(0, 100) <= prob * 100)
            {
                return prod;
            }
            return 0;
        }
        public List<string> GetMeans()
        {
            return _sizeAndNameOfMeans.Keys.ToList();
        }
    }
}
