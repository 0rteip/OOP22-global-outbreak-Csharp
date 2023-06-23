using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace farabegoli.disease
{
    public class DiseaseFactoryImpl : IDiseaseFactory
    {
        public IDisease CreateDisease(string diseaseType, float infectivity, float lethality,
            float airInfectivity, float landInfectivity, float seaInfectivity,
            float heatInfectivity, float coldInfectivity, float cureResistance,
            float humidityInfectivity, float aridityInfectivity, float povertyInfectivity)
        {
            return new DiseaseImpl(diseaseType, infectivity, lethality, airInfectivity, landInfectivity, seaInfectivity,
                heatInfectivity, coldInfectivity, cureResistance, humidityInfectivity, aridityInfectivity, povertyInfectivity);
        }
    }
}
