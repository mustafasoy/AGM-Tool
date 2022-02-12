using ArGeTesvikTool.Entities.Concrete.Business;

namespace ArGeTesvikTool.Business.Abstract.Business
{
    public interface IGroupInfoService
    {
        void Add(GroupInfoDto groupInfo);
        void Update(GroupInfoDto groupInfo);
        GroupInfoDto GetByYear(int year);
    }
}
