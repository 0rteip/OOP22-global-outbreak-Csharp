namespace carabini.region
{
    public class RegionImpl : IRegion
    {
        private long _numInfected;
        private long _numDeath;
        private long _deathByEvents;
        private readonly long _popTot;
        private readonly string _name;
        private readonly float _urban;
        private readonly float _poor;
        private readonly int _facilities;
        private readonly int _color;
        private readonly IClimate _climate;
        private RegionCureStatus _status = RegionCureStatus.NONE;
        // private State statusCure;
        private readonly List<ITransmissionMean> _trasmissionMeans = new();
        private readonly float _closeMeans;
        public RegionImpl(long popTot, string name,
                 Dictionary<string, Tuple<int, List<string>?>> reachableRegion, float urban,
                float poor, int color, int facilities, float hot, float humid,
                float closeMeans)
        {
            _popTot = popTot;
            _name = name;
            _urban = urban;
            _poor = poor;
            _color = color;
            _facilities = facilities;
            _climate = new ClimateImpl(humid, hot);
            _deathByEvents = 0;
            _closeMeans = closeMeans;
            CreateMeans(reachableRegion);
        }
        private void CreateMeans(Dictionary<string, Tuple<int, List<string>?>> reachableRegion)
        {
            foreach (var i in reachableRegion)
            {
                AddMeans(i.Value, i.Key);
            }
        }

        private void AddMeans(Tuple<int, List<string>?> info, string type)
        {
            int n = info.Item1;
            List<string>? list = info.Item2;
            for (int i = 0; i < n; i++)
            {
                _trasmissionMeans.Add(new TransmissionMeansImpl(list, type));
            }

        }
        public void IncDeathPeople(long death, bool byEvent)
        {
            if (_numInfected - death <= 0)
            {
                _numInfected = 0;
                //logger.warn("I can't remove this infect");
            }
            else
            {
                _numInfected -= death;
            }
            if (_numDeath < _popTot)
            {
                if (_numDeath + death >= _popTot)
                {
                    /*
                        if (this.numDeath + death > popTot)
                        {
                            //logger.warn("Too many death but I add those possible");
                        }
                        */
                    if (byEvent)
                    {
                        _deathByEvents += _popTot - _numDeath;
                    }
                    _numDeath = _popTot;
                    _status = RegionCureStatus.FINISHED;

                }
                else
                {
                    if (byEvent)
                    {
                        _deathByEvents += death;
                    }
                    _numDeath += death;
                }
                CheckAndCloseMeans();
            }
            /*
            else
            {
                logger.info("The state" + name + "is Finished");
            }
            */
        }

        private void CheckAndCloseMeans()
        {
            float deathT = _numDeath;
            float popT = _popTot;
            float deathE = _deathByEvents;
            if ((deathT - deathE) / popT >= _closeMeans && _trasmissionMeans[0].GetState() != MeansState.CLOSE)
            {
                _trasmissionMeans.ForEach(k =>
                {
                    k.SetState(MeansState.CLOSE);
                });
                //logger.info("Close " + this.name + " borders " + (deathT - deathE));
            }
        }

        public void IncOrDecInfectedPeople(long infected)
        {
            if (infected > 0)
            {
                if (!_status.Equals(RegionCureStatus.FINISHED))
                {
                    if (_numInfected + _numDeath < _popTot)
                    {
                        long sum = _numInfected + infected + _numDeath;
                        if (sum >= _popTot)
                        {
                            /*
                            if (sum > this._popTot)
                            {
                                logger.warn("Too many infected but I add those possible");
                            }

                            infodataSupport.firePropertyChange("infectedRegion", this.numInfected, sum);
                            */
                            _numInfected += _popTot - (_numInfected + _numDeath);
                        }
                        else
                        {
                            //infodataSupport.firePropertyChange("infectedRegion", this.numInfected, sum);
                            _numInfected += infected;
                        }
                    }
                }
                /*
                else
                {
                    logger.warn("State is already infected or RegionState is Finished");
                }
                */
            }
        }

        public long GetNumInfected()
        {
            return _numInfected;
        }

        public long GetNumDeath()
        {
            return _numDeath;
        }

        public string GetName()
        {
            return _name;
        }

        public float GetUrban()
        {
            return _urban;
        }

        public long GetPopTot()
        {
            return _popTot;
        }

        public float GetPoor()
        {
            return _poor;
        }

        public List<ITransmissionMean> GetTrasmissionMeans()
        {
            return new List<ITransmissionMean>(_trasmissionMeans);
        }

        public void SetCureStatus(RegionCureStatus started)
        {
            _status = started;
        }

        public long GetDeathByVirus()
        {
            return _numDeath - _deathByEvents;
        }

        public float CalcPercInfected()
        {
            float pop = _popTot;
            float infect = _numInfected;
            return infect / pop;
        }

        public RegionCureStatus GetCureStatus()
        {
            return _status;
        }

        public int GetFacilities()
        {
            return _facilities;
        }

        public int GetColor()
        {
            return _color;
        }

        public IClimate GetClimate()
        {
            return _climate;
        }
    }
}
