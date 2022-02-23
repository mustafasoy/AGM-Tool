using ArGeTesvikTool.Business.Abstract.RdCenterPerson;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenterPerson
{
    public class RdCenterPersonInfoManager : IRdCenterPersonInfoService
    {
        private readonly IRdCenterPersonInfoDal _rdCenterPerson;

        public RdCenterPersonInfoManager(IRdCenterPersonInfoDal rdCenterPerson)
        {
            _rdCenterPerson = rdCenterPerson;
        }

        public void Add(RdCenterPersonInfoDto rdCenterPersoInfo)
        {
            _rdCenterPerson.Add(rdCenterPersoInfo);
        }

        public void Update(RdCenterPersonInfoDto rdCenterPersoInfo)
        {
            _rdCenterPerson.Update(rdCenterPersoInfo);
        }

        public void Delete(int id)
        {
            _rdCenterPerson.Delete(new RdCenterPersonInfoDto { Id = id });
        }

        public RdCenterPersonInfoDto GetById(int id)
        {
            return _rdCenterPerson.Get(x => x.Id == id);
        }

        public List<RdCenterPersonInfoDto> GetAllByYear(int year)
        {
            return _rdCenterPerson.GetList(x=>x.Year == year);
        }
    }
}
