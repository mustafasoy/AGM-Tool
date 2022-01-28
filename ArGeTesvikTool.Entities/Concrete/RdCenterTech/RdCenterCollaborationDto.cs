using ArGeTesvikTool.Entities.Abstract;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterTech
{
    public class RdCenterCollaborationDto:IEntity
    {
        public int Id { get; set; }
        public string Collaboration { get; set; }
        public string Partner { get; set; }
        public string Country { get; set; }
        public string CollaborationType { get; set; }
    }
}
