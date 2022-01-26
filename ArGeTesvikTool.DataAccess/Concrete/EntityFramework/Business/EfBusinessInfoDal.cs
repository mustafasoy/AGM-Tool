using ArGeTesvikTool.Core.Data_Access.EntityFramework;
using ArGeTesvikTool.DataAccess.Abstract;
using ArGeTesvikTool.Entities.Concrete.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.DataAccess.Concrete.EntityFramework.Business
{
    public class EfBusinessInfoDal : EfEntityRepositoryBase<BusinessInfoDto, AGMDbContext>, IBusinessInfoDal
    {

    }
}
