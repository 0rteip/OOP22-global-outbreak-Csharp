using System.Collections.Generic;
using farabegoli.disease;
using farabegoli.diseasereader;
using farabegoli.temp;
using System.IO;

namespace TestDisease.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

                const int _initialInfects = 55_000;
                const int _initialDeaths = 5_000;
        private class RegionImpl : IRegion
            {
                private const long _population = 1_000_000;
                private const float _poor = 0.2f;
                private const float _urban = 0.4f;
                private const float _hot = 0.9f;
                private const float _cold = 0.1f;
                private const float _arid = 0.1f;
                private const float _humid = 0.9f;
                private long _deaths = _initialDeaths;
                private long _infected = _initialInfects;
                private IClimate _climate = new ClimateImpl();

                private class ClimateImpl : IClimate
                {
                    public float Hot { get; } = _hot;
                    public float Cold { get; } = _cold;
                    public float Arid { get; } = _arid;
                    public float Humid { get; } = _humid;
                }


                public long Population => _population;
                public float Poor => _poor;
                public float Urban => _urban;
                public long Deaths => _deaths;
                public long Infected => _infected;
                public IClimate Climate => _climate;
                public void IncDeathPeople(long calculateNewDeaths)
                {
                    this._deaths += calculateNewDeaths;
                }

                public void IncOrDecInfectedPeople(long calculateNewInfected)
                {
                    this._infected += calculateNewInfected;
                }
            }

        [Test]
        public void Test1()
        {
            IRegion region = new RegionImpl();
            IDiseaseReader reader = new DiseaseReaderImpl();
            DiseaseDataList diseasesList = new DiseaseDataList();
            diseasesList.SetDisease(reader.GetDiseases());
            DiseaseData diseaseData = diseasesList.GetDisease().First();
            IDiseaseFactory diseaseFactory = new DiseaseFactoryImpl();
            if(diseaseData.Type != null){
                IDisease disease = diseaseFactory.CreateDisease(diseaseData.Type, diseaseData.Infectivity, diseaseData.Lethality, diseaseData.AirInfectivity, diseaseData.LandInfectivity, diseaseData.SeaInfectivity, diseaseData.HeatInfectivity, diseaseData.ColdInfectivity, diseaseData.CureResistance, diseaseData.AridityInfectivity, diseaseData.HumidityInfectivity, diseaseData.PovertyInfectivity);
                disease.Name = "Malattia";
                Assert.That(diseaseData.Infectivity, Is.EqualTo(disease.Infectivity));

                List<IRegion> regionList = new List<IRegion>();
                regionList.Add(region);

                float expectedInfectivity = (float)(disease.Infectivity * region.Urban
                    + disease.AridityInfectivity * region.Climate.Arid
                    + disease.HumidityInfectivity * region.Climate.Humid
                    + disease.ColdInfectivity * region.Climate.Cold
                    + disease.HeatInfectivity * region.Climate.Hot
                    + disease.PovertyInfectivity * region.Poor);

                long expectedInfected = (long)(region.Infected * expectedInfectivity) + region.Infected;
                disease.InfectRegions(regionList);

                Assert.IsTrue(expectedInfected <= region.Infected && region.Infected <= expectedInfected + 4);

                long expectedDeaths = (long)System.Math.Ceiling(region.Infected * disease.Lethality) + region.Deaths;
                disease.KillPeopleRegions(regionList);

                Assert.That(expectedDeaths, Is.EqualTo(region.Deaths));
                Console.WriteLine("Test effettuato correttamente");
            }
        }
    }
}