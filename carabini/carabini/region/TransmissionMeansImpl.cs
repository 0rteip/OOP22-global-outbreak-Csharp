namespace carabini.region
{
    public class TransmissionMeansImpl : ITransmissionMean
    {
        private readonly List<string>? _reachableStates;
        private readonly string _mean;
        private MeansState _state = MeansState.OPEN;

        public TransmissionMeansImpl(List<string>? reachableStates, string type)
        {
            _reachableStates = reachableStates;
            _mean = type;
        }
        public List<string>? GetReachableStates()
        {
            return _reachableStates;
        }

        public MeansState GetState()
        {
            return _state;
        }

        public string GetMeans()
        {
            return _mean;
        }

        public void SetState(MeansState state)
        {
            _state = state;
        }
    }
}
