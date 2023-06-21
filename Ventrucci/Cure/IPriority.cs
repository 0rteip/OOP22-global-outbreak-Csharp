namespace OOP22_global_outbreak_Csharp.Ventrucci.Cure;

/// <summary>
/// Priority Interface.
/// </summary>
public interface IPriority
{
    /// <summary>
    /// Priority number.
    /// </summary>
    int Priority { get; }

    /// <summary>
    /// Priority description.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Resource percentage used for Priority.
    /// </summary>
    float ResourcesPercentage { get; }

    /// <summary>
    /// Detection rate of Priority.
    /// </summary>
    float DetectionRate { get; }
}
