namespace farabegoli.disease
{
    public class DiseaseData
    {
        private float infectivity;
        private float lethality;
        private float airInfectivity;
        private float landInfectivity;
        private float seaInfectivity;
        private float heatInfectivity;
        private float coldInfectivity;
        private float cureResistance;
        private float humidityInfectivity;
        private float aridityInfectivity;
        private float povertyInfectivity;

        public string? Type { get; set; }

        public float Infectivity
        {
            get { return infectivity; }
            set { infectivity = value; }
        }

        public float Lethality
        {
            get { return lethality; }
            set { lethality = value; }
        }

        public float AirInfectivity
        {
            get { return airInfectivity; }
            set { airInfectivity = value; }
        }

        public float LandInfectivity
        {
            get { return landInfectivity; }
            set { landInfectivity = value; }
        }

        public float SeaInfectivity
        {
            get { return seaInfectivity; }
            set { seaInfectivity = value; }
        }

        public float HeatInfectivity
        {
            get { return heatInfectivity; }
            set { heatInfectivity = value; }
        }

        public float ColdInfectivity
        {
            get { return coldInfectivity; }
            set { coldInfectivity = value; }
        }

        public float CureResistance
        {
            get { return cureResistance; }
            set { cureResistance = value; }
        }

        public float HumidityInfectivity
        {
            get { return humidityInfectivity; }
            set { humidityInfectivity = value; }
        }

        public float AridityInfectivity
        {
            get { return aridityInfectivity; }
            set { aridityInfectivity = value; }
        }

        public float PovertyInfectivity
        {
            get { return povertyInfectivity; }
            set { povertyInfectivity = value; }
        }
    }
}
