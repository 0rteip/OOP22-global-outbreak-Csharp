using carabini.region;

namespace carabini.events
{
    public class CauseEventImpl : ICauseEvent
    {
        private readonly List<IEvent> _events;
        private static readonly Random RANDOM = new();

        /**
         * 
         * @param events
         */
        public CauseEventImpl(List<IEvent> events)
        {
            _events = new(events);
        }
        public IExtractedEvent? CauseEvent(List<IRegion> regions)
        {
            IExtractedEvent? extracted = null;
            if (regions.Count > 0)
            {
                IEvent _event = _events[RANDOM.Next(0, _events.Count)];
                float prob = _event.GetProbOfHapp();
                float num = RANDOM.NextSingle();
                if (prob >= num)
                {
                    IRegion region = regions[RANDOM.Next(0, regions.Count)];
                    extracted = new ExtractedEventImpl(region.GetColor(), _event.GetName(), CalcDeath(region, _event.GetPercOfDeath()));
                }
            }
            return extracted;
        }
        private static long CalcDeath(IRegion region, float percOfDeath)
        {
            long death = (long)Math.Floor(region.GetPopTot() * percOfDeath);
            if (region.GetNumDeath() + death > region.GetPopTot())
            {
                death = region.GetPopTot() - region.GetNumDeath();
            }
            return death;
        }
    }
}
