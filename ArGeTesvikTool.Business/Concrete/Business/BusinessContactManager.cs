using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.DataAccess.Abstract;
using ArGeTesvikTool.Entities.Concrete.Business;

namespace ArGeTesvikTool.Business.Concrete.Business
{
    public class BusinessContactManager : IBusinessContactService
    {
        private readonly IBusinessContactDal _businessContactDal;

        public BusinessContactManager(IBusinessContactDal businessContactDal)
        {
            _businessContactDal = businessContactDal;
        }

        public void Add(BusinessContactDto businessContact)
        {
            _businessContactDal.Add(businessContact);
        }

        public void Update(BusinessContactDto businessContact)
        {
            _businessContactDal.Update(businessContact);
        }

        public BusinessContactDto GetByYear(int year)
        {
            return _businessContactDal.Get(x => x.Year == year);
        }
    }
}
