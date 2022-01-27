using ArGeTesvikTool.Entities.Abstract;

namespace ArGeTesvikTool.Entities.Concrete.Business
{
    public class PersonnelDistributionDto : IEntity
    {
        public int Id { get; set; }
        public string CompanyUnit { get; set; }
        public int PostDoctoral { get; set; }
        public int Doctoral { get; set; }
        public int MasterDegree { get; set; }
        public int BachelorDegree { get; set; }
        public int AssociateDegree { get; set; }
        public int HighSchool { get; set; }
        public int Total { get; set; }
    }
}
