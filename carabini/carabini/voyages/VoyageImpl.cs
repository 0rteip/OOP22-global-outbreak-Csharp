namespace carabini.voyages
{
    public class VoyageImpl : IVoyage
    {
        private readonly string _type;
        private readonly int _part;
        private readonly int _dest;
        private readonly long _infected;

        public VoyageImpl(string type, int part, int dest, long infected)
        {
            _type = type;
            _part = part;
            _dest = dest;
            _infected = infected;
        }
        public int GetDest()
        {
            return _dest;
        }

        public long GetInfected()
        {
            return this._infected;
        }

        public int GetPart()
        {
            return this._part;
        }

        public string GetMeans()
        {
            return _type;
        }
    }
}
