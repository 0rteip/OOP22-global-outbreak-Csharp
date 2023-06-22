namespace OOP22_global_outbreak_Csharp.Ventrucci.Cure;

/// <summary>
/// Cure Interface.
/// </summary>
public interface ICure
{
    /// <summary>
    /// A ICureData objects.
    /// </summary>
    ICureData GlobalStatus { get; }

    /// <summary>
    /// Research for cure.
    /// </summary>
    void Research();

    /// <summary>
    /// Is completed the CUre.
    /// </summary>
    bool IsCompleted { get; }

    /// <summary>
    /// Augemnt research difficulty.
    /// </summary>
    /// <param name="changeFactor">How much increase.</param>
    void IncreaseResearchDifficulty(float changeFactor);

    /// <summary>
    /// Reduce Progress done.
    /// </summary>
    /// <param name="changeFactor">How much decrease.</param>
    void ReduceResearchProgress(float changeFactor);

    /// <summary>
    /// Action to perform when CUre reach rilevant level.
    /// </summary>
    /// <param name="action">Action t perform</param>
    void AddAction(Action<int> action);

    /// <summary>
    /// Is consistent or not.
    /// </summary>
    bool IsConsistent { get; }
}
