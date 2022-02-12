using ArGeTesvikTool.Business.Abstract.RdCenter;
using ArGeTesvikTool.DataAccess.Abstract.RdCenter;
using ArGeTesvikTool.Entities.Concrete.RdCenter;

namespace ArGeTesvikTool.Business.Concrete.RdCenter
{
    public class RdCenterInfoManager : IRdCenterInfoService
    {
        private readonly IRdCenterInfoDal _centerInfoDal;

        public RdCenterInfoManager(IRdCenterInfoDal centerInfoDal)
        {
            _centerInfoDal = centerInfoDal;
        }
        public void Add(RdCenterInfoDto rdCenterInfo)
        {
            _centerInfoDal.Add(rdCenterInfo);
        }

        public void Update(RdCenterInfoDto rdCenterInfo)
        {
            _centerInfoDal.Update(rdCenterInfo);
        }

        public RdCenterInfoDto GetByYear(int year)
        {
            return _centerInfoDal.Get(x => x.Year == year);
        }
    }
}
