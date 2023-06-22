namespace OOP22_global_outbreak_Csharp.Ventrucci.Cure.Priority;

/// <summary>
/// Builder for CurePriority.
/// </summary>
public partial class CurePriority
{
    /// <summary>
    /// A CurePriority Builder.
    /// </summary>
    public class Builder
    {
        private static readonly int PRIORITY = 0;
        private static readonly string DESCRIPTION = "None";
        private static readonly float RESOURCES_PERCENTAGE = 0.12f;
        private static readonly float DETECTION_RATE = 0.000_02f;

        private int _priority = PRIORITY;
        private string _description = DESCRIPTION;
        private float _resourcesPercentage = RESOURCES_PERCENTAGE;
        private int _nextPriority = PRIORITY;
        private float _detectionRate = DETECTION_RATE;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="priority">priority</param>
        /// <returns>this builder, for method chaining</returns>
        public Builder SetPriority(int priority)
        {
            _priority = priority;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="description">description</param>
        /// <returns>this builder, for method chaining</returns>
        public Builder SetDescription(string description)
        {
            _description = description;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourcesPercentage">resourcesPercentage</param>
        /// <returns>this builder, for method chaining</returns>
        public Builder SetResourcesPercentage(float resourcesPercentage)
        {
            _resourcesPercentage = resourcesPercentage;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="detectionRate">detectionRate</param>
        /// <returns>this builder, for method chaining</returns>
        public Builder SetDetectionRate(float detectionRate)
        {
            _detectionRate = detectionRate;
            return this;
        }

        /// <summary>
        /// Create a IPriority.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public IPriority Build()
        {
            if (_priority != _nextPriority)
            {
                throw new InvalidOperationException("Incorrect Priority");
            }
            _nextPriority++;
            return new CurePriority(_priority, _description, _resourcesPercentage, _detectionRate);
        }
    }
}
