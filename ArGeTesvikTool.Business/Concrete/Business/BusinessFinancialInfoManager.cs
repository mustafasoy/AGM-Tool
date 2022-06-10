using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.DataAccess.Abstract.Business;
using ArGeTesvikTool.Entities.Concrete.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Business.Concrete.Business
{
    public class BusinessFinancialInfoManager : IBusinessFinancialInfoService
    {
        private readonly IBusinessFinancialInfoDal _businessFinancial;

        public BusinessFinancialInfoManager(IBusinessFinancialInfoDal businessFinancial)
        {
            _businessFinancial = businessFinancial;
        }

        public void Add(BusinessFinancialInfoDto businessFinancialInfo)
        {
            _businessFinancial.Add(businessFinancialInfo);
        }

        public void Update(BusinessFinancialInfoDto businessFinancialInfo)
        {
            _businessFinancial.Update(businessFinancialInfo);
        }

        public void Delete(int id)
        {
            _businessFinancial.Delete(new BusinessFinancialInfoDto { Id = id });
        }

        public BusinessFinancialInfoDto GetById(int id)
        {
            return _businessFinancial.Get(x => x.Id == id);
        }

        public BusinessFinancialInfoDto GetByYear(int year)
        {
            return _businessFinancial.Get(x => x.Year == year);
        }

        public List<BusinessFinancialInfoDto> GetAll()
        {
            return _businessFinancial.GetList();
        }
    }
}
