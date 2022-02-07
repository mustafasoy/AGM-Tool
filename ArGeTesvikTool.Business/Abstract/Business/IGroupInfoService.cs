using ArGeTesvikTool.Entities.Concrete.Business;

namespace ArGeTesvikTool.Business.Abstract.Business
{
    public interface IGroupInfoService
    {
        void Add(GroupInfoDto groupInfo);
        void Update(GroupInfoDto groupInfo);
        void Delete(int id);
        GroupInfoDto GetByYear(int year);
    }
}
