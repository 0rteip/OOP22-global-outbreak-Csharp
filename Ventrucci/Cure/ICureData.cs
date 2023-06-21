using OOP22_global_outbreak_Csharp.Ventrucci.Cure.Priority;
using OOP22_global_outbreak_Csharp.Ventrucci.Region;

namespace OOP22_global_outbreak_Csharp.Ventrucci.Cure;

/// <summary>
/// CureData returns Cure status and usefull info.
/// </summary>
public interface ICureData
{
    /// <summary>
    /// Progress percentace.
    /// </summary>
    int Progress { get; }

    /// <summary>
    /// How many days left till completing Cure.
    /// </summary>
    int? RemainingDays { get; }

    /// <summary>
    /// A list of Major Contributors.
    /// </summary>
    List<IRegion> MajorContributors { get; }

    /// <summary>
    /// The current Priority.
    /// </summary>
    IPriority Priority { get; }
}
