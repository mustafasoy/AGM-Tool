using ArGeTesvikTool.Core.Entities;

namespace ArGeTesvikTool.Entities.Concrete.Business
{
    public class PersonnelDistributionDto : AuditableEntity
    {
        public CompanyUnit CompanyUnit { get; set; }
        public int PostDoctoral { get; set; }
        public int Doctoral { get; set; }
        public int MasterDegree { get; set; }
        public int BachelorDegree { get; set; }
        public int AssociateDegree { get; set; }
        public int HighSchool { get; set; }
        public int Total { get; set; }
    }

    public enum CompanyUnit
    {
        Idari = 1,
        Mali = 2,
        Teknik = 3,
    }
}
