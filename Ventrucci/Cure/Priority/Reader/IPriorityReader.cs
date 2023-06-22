namespace OOP22_global_outbreak_Csharp.Ventrucci.Cure.Priority.Reader;

/// <summary>
/// Interface for Priority Reader.
/// </summary>
public interface IPriorityReader
{
    /// <summary>
    /// Returns a priority list.
    /// </summary>
    /// <returns>Listof Priority.</returns>
    List<IPriority> GetPriorities();
}