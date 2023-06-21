namespace carabini.region
{
    public interface IRegion
    {

        void IncDeathPeople(long death, bool byEvent);

        long GetDeathByVirus();

        void IncOrDecInfectedPeople(long infected);

        float CalcPercInfected();

        long GetNumInfected();

        long GetNumDeath();

        RegionCureStatus GetCureStatus();

        string GetName();

        float GetUrban();

        long GetPopTot();

        float GetPoor();

        int GetFacilities();

        int GetColor();

        IClimate GetClimate();

        List<ITransmissionMean> GetTrasmissionMeans();

        void SetCureStatus(RegionCureStatus started);

    }
}
