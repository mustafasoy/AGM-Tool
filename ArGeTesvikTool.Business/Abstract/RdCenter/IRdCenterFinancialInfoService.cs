using ArGeTesvikTool.Entities.Concrete.RdCenter;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenter
{
    public interface IRdCenterFinancialInfoService
    {
        void Add(RdCenterFinancialInfoDto rdCenterFinancialInfo);
        void Update(RdCenterFinancialInfoDto rdCenterFinancialInfo);
        void Delete(int id);
        RdCenterFinancialInfoDto GetById(int id);
        List<RdCenterFinancialInfoDto> GetAll();
    }
}
