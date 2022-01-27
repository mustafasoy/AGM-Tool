using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.DataAccess.Abstract;
using ArGeTesvikTool.Entities.Concrete.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Business.Concrete.Business
{
    public class BusinessIntroManager : IBusinessIntroService
    {
        private IBusinessIntroDal _businessIntroDal;

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

        public void Delete(int id)
        {
            _businessIntroDal.Delete(new BusinessIntroDto { Id = id });
        }

        public BusinessIntroDto GetByYear(int year)
        {
            return _businessIntroDal.Get(x => x.Year == year);
        }
    }
}
