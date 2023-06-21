namespace carabini.region
{
    public class ClimateImpl : IClimate
    {
        private readonly float _arid;
        private readonly float _humid;
        private readonly float _cold;
        private readonly float _hot;

        public ClimateImpl(float humid, float hot)
        {
            _humid = humid;
            _hot = hot;
            _arid = 1 - humid;
            _cold = 1 - hot;
        }

        public float Getarid()
        {
            return _arid;
        }

        public float GetHumid()
        {
            return _humid;
        }

        public float GetHot()
        {
            return _hot;
        }

        public float GetCold()
        {
            return _cold;
        }
    }
}
