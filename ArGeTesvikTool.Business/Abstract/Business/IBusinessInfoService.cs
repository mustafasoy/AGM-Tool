using ArGeTesvikTool.Entities.Concrete.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Business.Abstract.Business
{
    public interface IBusinessInfoService
    {
        void Add(BusinessInfoDto businessInfo);
        void Update(BusinessInfoDto businessInfo);
        void Delete(int id);
        BusinessInfoDto GetById(int id);
    }
}
