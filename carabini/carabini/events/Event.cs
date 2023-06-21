namespace carabini.events
{
    public interface IEvent
    {
        float GetProbOfHapp();

        string GetName();

        float GetPercOfDeath();
    }
}
