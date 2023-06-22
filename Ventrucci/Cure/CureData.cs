using carabini.region;
using OOP22_global_outbreak_Csharp.Ventrucci.Cure.Priority;

namespace OOP22_global_outbreak_Csharp.Ventrucci.Cure
{
    /// <summary>
    /// CureData returns Cure status and useful info.
    /// </summary>
    public class CureData : ICureData
    {
        public int Progress { get; set; }
        public int? RemainingDays { get; set; }
        public List<IRegion>? MajorContributors { get; set; }
        public IPriority? Priority { get; set; }

        public override string ToString()
        {
            return "CureData [" + Priority + ", progress=" + Progress + ", contrib="
                + MajorContributors + ", days=" + RemainingDays + "]";
        }
    }
}
