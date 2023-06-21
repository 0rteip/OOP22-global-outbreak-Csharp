using carabini.region;
namespace carabini.voyages
{
    public interface IVoyages
    {
        List<IVoyage> ExtractVoyages(List<IRegion> regions, Dictionary<string, float> pot);

        List<string> GetMeans();
    }
}
