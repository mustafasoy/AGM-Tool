using ArGeTesvikTool.Entities.Concrete.Business;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.Business
{
    public interface IBusinessFinancialInfoService
    {
        void Add(BusinessFinancialInfoDto businessFinancialInfo);
        void Update(BusinessFinancialInfoDto businessFinancialInfo);
        void Delete(int id);
        BusinessFinancialInfoDto GetById(int id);
        BusinessFinancialInfoDto GetByYear(int year);
        List<BusinessFinancialInfoDto> GetAll();
    }
}
