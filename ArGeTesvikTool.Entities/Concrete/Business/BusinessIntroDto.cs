using ArGeTesvikTool.Entities.Abstract;

namespace ArGeTesvikTool.Entities.Concrete.Business
{
    public class BusinessIntroDto : IEntity
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Intro { get; set; }
    }
}
