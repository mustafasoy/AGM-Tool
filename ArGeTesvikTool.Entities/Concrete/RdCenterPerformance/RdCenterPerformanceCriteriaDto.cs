using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterPerformance
{
    public class RdCenterPerformanceCriteriaDto
    {
        public int Year { get; set; }
        public int PreYear { get; set; }
        public int TotalRDTurnover { get; set; }
        public int PreTotalRDTurnover { get; set; }
        public int RegistiredPatentNumber { get; set; }
        public int PreRegistiredPatentNumber { get; set; }
        public int IntSupportedrojectNumber { get; set; }
        public int PreIntSupportedrojectNumber { get; set; }
        public int MasterPersonnelRatio { get; set; }
        public int PreMasterPersonnelRatio { get; set; }
        public int TotalPersonnelRatio { get; set; }
        public int PreTotalPersonnelRatio { get; set; }
        public int TotalTurnoverRatio { get; set; }
        public int PreTotalTurnoverRatio { get; set; }
    }
}
