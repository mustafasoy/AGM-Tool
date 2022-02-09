using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.DataAccess.Abstract;
using ArGeTesvikTool.Entities.Concrete.Business;

namespace ArGeTesvikTool.Business.Concrete.Business
{
    public class BusinessInfoManager : IBusinessInfoService
    {
        private readonly IBusinessInfoDal _businessInfoDal;

        public BusinessInfoManager(IBusinessInfoDal businessInfoDal)
        {
            _businessInfoDal = businessInfoDal;
        }

        public void Add(BusinessInfoDto businessInfo)
        {
            _businessInfoDal.Add(businessInfo);
        }

        public void Update(BusinessInfoDto businessInfo)
        {
            _businessInfoDal.Update(businessInfo);
        }

        public void Delete(int id)
        {
            _businessInfoDal.Delete(new BusinessInfoDto { Id = id });
        }

        public BusinessInfoDto GetByYear(int year)
        {
            return _businessInfoDal.Get(x => x.Year == year);
        }
    }
}
