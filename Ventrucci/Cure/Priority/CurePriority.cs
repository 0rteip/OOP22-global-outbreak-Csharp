namespace OOP22_global_outbreak_Csharp.Ventrucci.Cure.Priority;

/// <summary>
/// CuPriority.
/// </summary>
public partial class CurePriority : IPriority
{
    private CurePriority(int priority, string description, float resourcesPercentage, float detectionRate)
    {
        Priority = priority;
        Description = description;
        ResourcesPercentage = resourcesPercentage;
        DetectionRate = detectionRate;
    }
    public int Priority { get; }

    public string Description { get; }

    public float ResourcesPercentage { get; }

    public float DetectionRate { get; }
}
