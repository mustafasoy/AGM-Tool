using System;

namespace ArGeTesvikTool.Entities.Concrete.Index
{
    public class EmploymentDto
    {
        public DateTime DocReceiptDate { get; set; }
        public int GraduateDoctoralNumber { get; set; }
        public int GraduateMasterDegreeNumber { get; set; }
        public int GraduateBachelorDegreeNumber { get; set; }
        public int CurrentDoctoralNumber { get; set; }
        public int CurrentMasterDegreeNumber { get; set; }
        public int GraduateBasicScienceNumber { get; set; }
        public int TechnicianNumber { get; set; }
        public int NewPersonTotalNumber { get; set; }
        public int TotalResearcherNumber { get; set; }
        public int WomenPersonNumber { get; set; }
        public int InternNumber { get; set; }
        public int OverSeasPersonNumber { get; set; }
    }
}
