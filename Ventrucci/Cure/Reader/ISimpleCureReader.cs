using carabini.region;

namespace OOP22_global_outbreak_Csharp.Ventrucci.Cure.Reader;

/// <summary>
/// Interface for SImpleCUre Reader.
/// </summary>
public interface ISimpleCureReader
{
    /// <summary>
    /// Returns a SimpleCure from a file.
    /// </summary>
    /// <param name="regions"></param>
    /// <returns></returns>
    SimpleCure GetSimpleCure(List<IRegion> regions);
}