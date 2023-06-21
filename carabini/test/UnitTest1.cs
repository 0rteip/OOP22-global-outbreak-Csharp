using carabini.events;
using carabini.region;
using carabini.voyages;
using region;
using voyageController;

namespace Test
{
    [TestClass]
    public class Test
    {
        readonly RegionController regionController = new();
        readonly VoyageController voyageController = new();
        readonly List<IRegion> _regions;
        public Test()
        {
            Console.WriteLine("aa");
            this._regions = regionController.GetRegions();
        }

        [TestMethod]
        public void RegionTest()
        {
            IRegion region = this._regions[0];
            region.IncDeathPeople(region.GetPopTot(), false);
            Assert.AreEqual(region.GetPopTot(), region.GetNumDeath());
            Assert.AreEqual(RegionCureStatus.FINISHED, region.GetCureStatus());

        }

        [TestMethod]
        public void VoyagesTest()
        {
            IVoyages means = voyageController.CreateVoyage();
            List<IRegion> regions = regionController.GetRegions();
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
            regions.ForEach(k=> {
                k.IncOrDecInfectedPeople(k.GetPopTot());
            });
            Console.WriteLine(regions[0].GetNumInfected());
             List<IVoyage> vo = means.ExtractVoyages(regions, pot);
             vo.ForEach(k => Console.WriteLine("means " + k.GetMeans() + " infected " + k.GetInfected()  +  " part " + k.GetPart() + " dest " +
             k.GetDest()));
        }

        [TestMethod]
        public void EventTest()
        {
            List<IEvent> events = new();
            List<IRegion> regions = new()
            {
                regionController.GetRegions()[0]
            };
            events.Add(new EventImpl("uragano", 1, 0.0001f));
            ICauseEvent cause = new CauseEventImpl(events);
            IExtractedEvent? extractedEvent = cause.CauseEvent(regions);
            Assert.IsNotNull(extractedEvent);
            Assert.AreEqual((long) Math.Floor(regions[0].GetPopTot() * 0.0001f), extractedEvent.GetDeath());
        }
    }
}
