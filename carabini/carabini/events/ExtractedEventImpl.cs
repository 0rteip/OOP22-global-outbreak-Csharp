namespace carabini.events
{
    public class ExtractedEventImpl : IExtractedEvent
    {
        private readonly int _region;
        private readonly string _event;
        private readonly long _death;

        /**
         * 
         * @param region
         *               region
         * @param event
         *               event's name
         * @param death
         *               new death
         */
        public ExtractedEventImpl(int region, string _event, long death)
        {
            _region = region;
            this._event = _event;
            _death = death;
        }
        public long GetDeath()
        {
            return _death;
        }

        public string GetEvent()
        {
            return _event;
        }

        public int GetRegion()
        {
            return _region;
        }
    }
}
