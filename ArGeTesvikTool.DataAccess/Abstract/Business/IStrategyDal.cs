using ArGeTesvikTool.Core.Data_Access;
using ArGeTesvikTool.Entities.Concrete.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.DataAccess.Abstract.Business
{
    public interface IStrategyDal : IEntityRepository<StrategyDto>
    {
        //custom operations for business info class, that should be written here. like; store procedure or join query
    }
}
