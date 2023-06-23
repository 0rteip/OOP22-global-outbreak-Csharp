using farabegoli.temp;

namespace farabegoli.disease
{
    public interface IDisease
    {
        string? Name { get; set; }
        string Type { get; set; }
        float Infectivity { get; }
        float Lethality { get; }
        float AirInfectivity { get; }
        float LandInfectivity { get; }
        float SeaInfectivity { get; }
        float HeatInfectivity { get; }
        float ColdInfectivity { get; }
        float CureResistance { get; }
        float HumidityInfectivity { get; }
        float AridityInfectivity { get; }
        float PovertyInfectivity { get; }
        void UpdateInfectivity(float value);
        void UpdateLethality(float value);
        void UpdateAirInfectivity(float value);
        void UpdateSeaInfectivity(float value);
        void UpdateLandInfectivity(float value);
        void UpdateHeatInfectivity(float value);
        void UpdateColdInfectivity(float value);
        void UpdateHumidityInfectivity(float value);
        void UpdateAridityInfectivity(float value);
        void UpdateCureResistance(float value);
        void UpdatePovertyInfectivity(float value);
        void KillPeopleRegions(List<IRegion> regionList);
        void InfectRegions(List<IRegion> regionList);
    }
}

