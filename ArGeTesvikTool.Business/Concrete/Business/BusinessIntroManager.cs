using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.DataAccess.Abstract;
using ArGeTesvikTool.Entities.Concrete.Business;

namespace ArGeTesvikTool.Business.Concrete.Business
{
    public class BusinessIntroManager : IBusinessIntroService
    {
        private readonly IBusinessIntroDal _businessIntroDal;

        public BusinessIntroManager(IBusinessIntroDal businessIntroDal)
        {
            _businessIntroDal = businessIntroDal;
        }

        public void Add(BusinessIntroDto businessIntro)
        {
            _businessIntroDal.Add(businessIntro);
        }

        public void Update(BusinessIntroDto businessIntro)
        {
            _businessIntroDal.Update(businessIntro);
        }


        public BusinessIntroDto GetByYear(int year)
        {
            return _businessIntroDal.Get(x => x.Year == year);
        }
    }
}
