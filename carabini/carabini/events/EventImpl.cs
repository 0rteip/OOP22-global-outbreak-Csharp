namespace carabini.events
{
    public class EventImpl : IEvent
    {
        private readonly float _probOfHapp;
        private readonly float _percOfDeath;
        private readonly string _name;

        public EventImpl(string name, float probOfHapp, float percOfDeath)
        {
            this._name = name;
            this._probOfHapp = probOfHapp;
            this._percOfDeath = percOfDeath;
        }

        public string GetName()
        {
            return this._name;
        }

        public float GetPercOfDeath()
        {
            return this._percOfDeath;
        }

        public float GetProbOfHapp()
        {
            return this._probOfHapp;
        }
    }
}
