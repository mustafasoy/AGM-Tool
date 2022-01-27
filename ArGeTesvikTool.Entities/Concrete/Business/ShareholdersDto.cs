using ArGeTesvikTool.Entities.Abstract;

namespace ArGeTesvikTool.Entities.Concrete.Business
{
    public class ShareholdersDto : IEntity
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Origin { get; set; }
        public decimal Share { get; set; }
        public decimal ShareAmount { get; set; }
    }
}
