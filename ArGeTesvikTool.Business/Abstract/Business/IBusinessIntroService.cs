using ArGeTesvikTool.Entities.Concrete.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Business.Abstract.Business
{
    public interface IBusinessIntroService
    {
        void Add(BusinessIntroDto businessInfo);
        void Update(BusinessIntroDto businessInfo);
        void Delete(int id);
        BusinessIntroDto GetByYear(int year);
    }
}
