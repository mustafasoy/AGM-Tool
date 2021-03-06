using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.DataAccess.Abstract;
using ArGeTesvikTool.Entities.Concrete.Business;

namespace ArGeTesvikTool.Business.Concrete.Business
{
    public class GroupInfoManager : IGroupInfoService
    {
        private readonly IGroupInfoDal _groupInfoDal;

        public GroupInfoManager(IGroupInfoDal groupInfoDal)
        {
            _groupInfoDal = groupInfoDal;
        }

        public void Add(GroupInfoDto groupInfo)
        {
            _groupInfoDal.Add(groupInfo);
        }

        public void Update(GroupInfoDto groupInfo)
        {
            _groupInfoDal.Update(groupInfo);
        }

        public GroupInfoDto GetByYear(int year)
        {
            return _groupInfoDal.Get(x => x.Year == year);
        }
    }
}
