using ArGeTesvikTool.Business.Abstract.RdCenter;
using ArGeTesvikTool.DataAccess.Abstract.RdCenter;
using ArGeTesvikTool.Entities.Concrete.RdCenter;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenter
{
    public class RdCenterFinancialInfoManager : IRdCenterFinancialInfoService
    {
        private readonly IRdCenterFinancialInfoDal _rdCenterFinancial;

        public RdCenterFinancialInfoManager(IRdCenterFinancialInfoDal rdCenterFinancial)
        {
            _rdCenterFinancial = rdCenterFinancial;
        }

        public void Add(RdCenterFinancialInfoDto rdCenterFinancialInfo)
        {
            _rdCenterFinancial.Add(rdCenterFinancialInfo);
        }

        public void Update(RdCenterFinancialInfoDto rdCenterFinancialInfo)
        {
            _rdCenterFinancial.Update(rdCenterFinancialInfo);
        }

        public void Delete(int id)
        {
            _rdCenterFinancial.Delete(new RdCenterFinancialInfoDto { Id = id });
        }

        public RdCenterFinancialInfoDto GetById(int id)
        {
            return _rdCenterFinancial.Get(x => x.Id == id);
        }

        public List<RdCenterFinancialInfoDto> GetAll()
        {
            return _rdCenterFinancial.GetList();
        }
    }
}
