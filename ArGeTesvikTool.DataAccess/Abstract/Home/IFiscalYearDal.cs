using ArGeTesvikTool.Core.Data_Access;
using ArGeTesvikTool.Entities.Concrete;

namespace ArGeTesvikTool.DataAccess.Abstract
{
    public interface IFiscalYearDal : IEntityRepository<FiscalYearDto>
    {
        //custom operations for business info class, that should be written here. like; store procedure or join query
    }
}

