namespace carabini.region
{
    public interface ITransmissionMean
    {
        List<string>? GetReachableStates();

        MeansState GetState();

        void SetState(MeansState state);

        string GetMeans();

    }
}
