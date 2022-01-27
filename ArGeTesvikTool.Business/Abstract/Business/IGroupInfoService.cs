using ArGeTesvikTool.Entities.Concrete.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Business.Abstract.Business
{
    public interface IGroupInfoService
    {
        void Add(GroupInfoDto businessInfo);
        void Update(GroupInfoDto businessInfo);
        void Delete(int id);
    }
}
