using carabini.events;
using carabini.region;
using carabini.voyages;
using NUnit.Framework;

namespace carabini.Test
{
    [TestFixture]
    public class Test
    {
        private readonly static string REGION1_NAME = "Canada";
        private readonly static int REGION1_COLOR = -62442;
        private readonly static int REGION1_PORTS = 1;
        private readonly static int REGION1_AIRPORTS = 1;
        private readonly static List<string> REGION1_BORDERS = new()
        {
            "Stati Uniti"
        };
        private readonly static float REGION1_HUMID = 0.6f;
        private readonly static float REGION1_HOT = 0.3f;
        private readonly static int REGION1_TOTAL_POPULATION = 35158304;
        private readonly static int REGION1_FACILITIES = 10;
        private readonly static float REGION1_POOR = 0.10f;
        private readonly static float REGION1_URBAN = 0.8f;
        private readonly static float REGION1_CLOSE_MEANS = 0.8f;
        private readonly static string REGION2_NAME = "Stati Uniti";
        private readonly static int REGION2_COLOR = -16773410;
        private readonly static int REGION2_PORTS = 1;
        private readonly static int REGION2_AIRPORTS = 1;
        private readonly static List<string> REGION2_BORDERS = new()
        {
             "Canada"
        };
        private readonly static float REGION2_HUMID = 0.6f;
        private readonly static float REGION2_HOT = 0.3f;
        private readonly static int REGION2_TOTAL_POPULATION = 35158304;
        private readonly static int REGION2_FACILITIES = 10;
        private readonly static float REGION2_POOR = 0.10f;
        private readonly static float REGION2_URBAN = 0.8f;
        private readonly static float REGION2_CLOSE_MEANS = 0.8f;
        private static readonly List<string> MEANS = new()
        {
            "terra", "aereoporti", "porti"
        };
        private readonly static int MEAN_SIZE = 300;
        private readonly static int MEAN_TIMES = 4;

        private static Dictionary<string, Tuple<int, int>> CreateDictionaryVoyages()
        {
            Dictionary<string, Tuple<int, int>> sizeAndNameOfMeans = new();
            MEANS.ForEach(k => sizeAndNameOfMeans.Add(k, new(MEAN_TIMES, MEAN_SIZE)));
            return sizeAndNameOfMeans;
        }
        private static List<IRegion> CreateRegions()
        {
            List<IRegion> regions = new();
            regions.Add(new RegionImpl(REGION1_TOTAL_POPULATION, REGION1_NAME, CreateDictionary(true, REGION1_AIRPORTS, REGION1_PORTS), REGION1_URBAN, REGION1_POOR, REGION1_COLOR,
                        REGION1_FACILITIES, REGION1_HOT, REGION1_HUMID, REGION1_CLOSE_MEANS));
            regions.Add(new RegionImpl(REGION2_TOTAL_POPULATION, REGION2_NAME, CreateDictionary(false, REGION2_AIRPORTS, REGION2_PORTS), REGION2_URBAN, REGION2_POOR, REGION2_COLOR,
                        REGION2_FACILITIES, REGION2_HOT, REGION2_HUMID, REGION2_CLOSE_MEANS));
            return regions;
        }

        private static Dictionary<string, Tuple<int, List<string>?>> CreateDictionary(bool isFirst, int air, int port)
        {
            Dictionary<string, Tuple<int, List<string>?>> reachableRegion = new();
            List<string> borders = REGION1_BORDERS;
            if (!isFirst)
            {
                borders = REGION2_BORDERS;
            }
            reachableRegion.Add(MEANS[0], new(1, borders));
            if (air > 0)
            {
                reachableRegion.Add(MEANS[1], new(air, new()));
            }
            if (port > 0)
            {
                reachableRegion.Add(MEANS[2], new(port, new()));
            }
            return reachableRegion;

        }
        [Test]
        public void RegionTest()
        {
            IRegion region = CreateRegions()[0];
            region.IncDeathPeople(region.GetPopTot(), false);
            Assert.AreEqual(region.GetPopTot(), region.GetNumDeath());
            Assert.AreEqual(RegionCureStatus.FINISHED, region.GetCureStatus());

        }

        [Test]
        public void VoyagesTest()
        {
            IVoyages means = new VoyagesImpl(CreateDictionaryVoyages());
            List<IRegion> regions = CreateRegions();
            // System.out.println(means.getMeans());
            Dictionary<string, float> pot = new();
            float v = 0;
            float a = 0;
            pot.Add("terra", v);
            pot.Add("aereoporti", a);
            pot.Add("porti", v);
            foreach (var elem in pot)
            {
                Assert.IsTrue(means.GetMeans().Contains(elem.Key));
            }
            regions.ForEach(k => {
                k.IncOrDecInfectedPeople(k.GetPopTot());
            });
            Console.WriteLine(regions[0].GetNumInfected());
            List<IVoyage> vo = means.ExtractVoyages(regions, pot);
            vo.ForEach(k => Console.WriteLine("means " + k.GetMeans() + " infected " + k.GetInfected() + " part " + k.GetPart() + " dest " +
            k.GetDest()));
        }

        [Test]
        public void EventTest()
        {
            List<IEvent> events = new();
            List<IRegion> regions = new()
            {
                CreateRegions()[0]
            };
            events.Add(new EventImpl("uragano", 1, 0.0001f));
            ICauseEvent cause = new CauseEventImpl(events);
            IExtractedEvent? extractedEvent = cause.CauseEvent(regions);
            if(extractedEvent != null)
            {
            Assert.AreEqual((long)Math.Floor(regions[0].GetPopTot() * 0.0001f), extractedEvent.GetDeath());
            }
        }
    }
}
