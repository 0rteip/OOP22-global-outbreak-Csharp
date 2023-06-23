namespace farabegoli.disease
{
    public interface IDiseaseFactory
    {
        IDisease CreateDisease(string type, float infectivity, float lethality, float airTransmission,
                float seaTransmission, float landTransmission,
                float heatTransmission, float coldTransmission, float cureResistance,
                float humidityResistance, float aridityResistance, float povertyTransmission);
    }
}

