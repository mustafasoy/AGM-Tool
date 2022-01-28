using ArGeTesvikTool.Entities.Abstract;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterTech
{
    public class RdCenterSoftwareDto : IEntity
    {
        public int Id { get; set; }
        public string SoftwareName { get; set; }
        public int CopyNumber { get; set; }
    }
}
