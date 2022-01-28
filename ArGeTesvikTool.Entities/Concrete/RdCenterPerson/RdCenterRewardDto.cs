using ArGeTesvikTool.Entities.Abstract;

namespace ArGeTesvikTool.Entities.Concrete.RdCenterPerson
{
    public class RdCenterRewardDto : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}