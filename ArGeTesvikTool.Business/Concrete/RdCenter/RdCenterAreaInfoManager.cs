using ArGeTesvikTool.Business.Abstract.RdCenter;
using ArGeTesvikTool.DataAccess.Abstract.RdCenter;
using ArGeTesvikTool.Entities.Concrete.RdCenter;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenter
{
    public class RdCenterAreaInfoManager : IRdCenterAreaInfoService
    {
        private readonly IRdCenterAreaInfoDal _areaInfoDal;

        public RdCenterAreaInfoManager(IRdCenterAreaInfoDal areaInfoDal)
        {
            _areaInfoDal = areaInfoDal;
        }

        public void Add(RdCenterAreaInfoDto rdCenterAreaInfo)
        {
            _areaInfoDal.Add(rdCenterAreaInfo);
        }

        public void Update(RdCenterAreaInfoDto rdCenterAreaInfo)
        {
            _areaInfoDal.Update(rdCenterAreaInfo);
        }

        public void Delete(int id)
        {
            _areaInfoDal.Delete(new RdCenterAreaInfoDto { Id = id });
        }

        public RdCenterAreaInfoDto GetById(int id)
        {
            return _areaInfoDal.Get(x => x.Id == id);
        }

        public List<RdCenterAreaInfoDto> GetAllByYear(int year)
        {
            return _areaInfoDal.GetList(x => x.Year == year);
        }

    }
}
