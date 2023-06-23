using System;
using farabegoli.temp;

namespace farabegoli.disease
{
    public class DiseaseImpl : IDisease
    {
    private static readonly int MIN_VALUE = 0;
        private static readonly int MAX_VALUE = 5;

        private string _name;
        private string _type;
        private float _infectivity;
        private float _lethality;
        private float _airInfectivity;
        private float _landInfectivity;
        private float _seaInfectivity;
        private float _heatInfectivity;
        private float _coldInfectivity;
        private float _cureResistance;
        private float _humidityInfectivity;
        private float _aridityInfectivity;
        private float _povertyInfectivity;
        private readonly Random _random;

        public DiseaseImpl(string _diseaseType, float _diseaseInfectivity, float _diseaseLethality,
            float _diseaseAirInfectivity, float _diseaseSeaInfectivity, float _diseaseLandInfectivity,
            float _diseaseHeatInfectivity, float _diseaseColdInfectivity, float _diseaseCureResistance,
            float _diseaseHumidityInfectivity, float _diseaseAridityInfectivity, float _diseasePovertyInfectivity)
        {
            this._type = _diseaseType;
            this._infectivity = _diseaseInfectivity;
            this._lethality = _diseaseLethality;
            this._airInfectivity = _diseaseAirInfectivity;
            this._landInfectivity = _diseaseLandInfectivity;
            this._seaInfectivity = _diseaseSeaInfectivity;
            this._heatInfectivity = _diseaseHeatInfectivity;
            this._coldInfectivity = _diseaseColdInfectivity;
            this._cureResistance = _diseaseCureResistance;
            this._humidityInfectivity = _diseaseHumidityInfectivity;
            this._aridityInfectivity = _diseaseAridityInfectivity;
            this._povertyInfectivity = _diseasePovertyInfectivity;
            this._random = new Random();
        }

        public string Name { 
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public float Infectivity => this._infectivity;
        public float Lethality => this._lethality;
        public float AirInfectivity => this._airInfectivity;
        public float LandInfectivity => this._landInfectivity;
        public float SeaInfectivity => this._seaInfectivity;
        public float HeatInfectivity => this._heatInfectivity;
        public float ColdInfectivity => this._coldInfectivity;
        public float CureResistance => this._cureResistance; 
        public float HumidityInfectivity => this._humidityInfectivity;
        public float AridityInfectivity => this._aridityInfectivity;
        public float PovertyInfectivity => this._povertyInfectivity; 
        public void UpdateInfectivity(float value)
        {
            this._infectivity = GetParameterUpdate(this._infectivity + value, "Infectivity");
        }
        public void UpdateLethality(float value)
        {
            this._lethality = GetParameterUpdate(this._lethality + value, "Lethality");
        }
        public void UpdateAirInfectivity(float value)
        {
            this._airInfectivity = GetParameterUpdate(this._airInfectivity + value, "AirInfectivity");
        }
        public void UpdateSeaInfectivity(float value)
        {
            this._seaInfectivity = GetParameterUpdate(this._seaInfectivity + value, "AirInfectivity");
        }
        public void UpdateLandInfectivity(float value)
        {
            this._landInfectivity = GetParameterUpdate(this._landInfectivity + value, "LandInfectivity");
        }
        public void UpdateHeatInfectivity(float value)
        {
            this._heatInfectivity = GetParameterUpdate(this._heatInfectivity + value, "HeatInfectivity");
        }
        public void UpdateColdInfectivity(float value)
        {
            this._coldInfectivity = GetParameterUpdate(this._coldInfectivity + value, "ColdInfectivity");
        }
        public void UpdateHumidityInfectivity(float value)
        {
            this._humidityInfectivity = GetParameterUpdate(this._humidityInfectivity + value, "HumidityInfectivity");
        }
        public void UpdateAridityInfectivity(float value)
        {
            this._aridityInfectivity = GetParameterUpdate(this._aridityInfectivity + value, "AridityInfectivity");
        }
        public void UpdateCureResistance(float value)
        {
            this._cureResistance = GetParameterUpdate(this._cureResistance + value, "CureResistance");
        }
        public void UpdatePovertyInfectivity(float value)
        {
            this._povertyInfectivity = GetParameterUpdate(this._povertyInfectivity + value, "PovertyInfectivity");
        }
        public void KillPeopleRegions(List<IRegion> regionList)
        {
            regionList.Where(region => region.Infected > 0)
                    .ToList()
                    .ForEach(region =>
                    {
                        region.IncDeathPeople(CalculateNewDeaths(region.Infected));
                    });
        }
        public void InfectRegions(List<IRegion> regionList)
        {
            regionList.Where(region => region.Infected > 0)
                    .Where(region => region.Infected + region.Deaths < region.Population)
                    .ToList()
                    .ForEach(region =>
                    {
                        long newInfected = CalculateNewInfected(region.Population, region.Infected, region.Urban, region.Poor,
                                                                region.Climate.Arid, region.Climate.Cold, region.Climate.Hot, region.Climate.Humid);
                        long maxNewInfected = region.Population - region.Infected - region.Deaths;
                        long finalNewInfected = newInfected > maxNewInfected ? maxNewInfected : newInfected;

                        region.IncOrDecInfectedPeople(finalNewInfected);
                    });
        }


        private long CalculateNewInfected(long population, long currentInfected, float urban, float poor, float arid, float cold,
        float hot, float humid)
        {
            if (CheckIfPositive(population, "population") &&
                CheckIfPositive(currentInfected, "currentInfected") &&
                CheckIfPositive(urban, "urban") &&
                CheckIfPositive(poor, "poor"))
            {
                return (long)Math.Round(population * ((float)currentInfected / population) *
                    CalculateInfectivity(urban, hot, cold, humid, arid, poor) +
                    _random.Next(MIN_VALUE, MAX_VALUE));
            }
            return 0;
        }

        private float CalculateInfectivity(float urban, float poor, float hot, float cold, float humidity, float aridity)
        {
            return Infectivity * urban + HeatInfectivity * hot + ColdInfectivity * cold +
                HumidityInfectivity * humidity + AridityInfectivity * aridity +
                PovertyInfectivity * poor;
        }

        private long CalculateNewDeaths(long infected)
        {
            if (CheckIfPositive(infected, "infected"))
            {
                return (long)Math.Ceiling(infected * Lethality);
            }
            return 0L;
        }

        private static bool CheckIfPositive(float number, string name)
        {
            if (number < 0)
            {
                return false;
            }
            return true;
        }

        private static float GetParameterUpdate(float value, string name)
        {
            float maxValue = 0.16f;
            if (value < 0 || value > maxValue)
            {
                return 0;
            }
            return value;
        }
    }
}