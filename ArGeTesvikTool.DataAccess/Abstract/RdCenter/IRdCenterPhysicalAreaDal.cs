using ArGeTesvikTool.Core.Data_Access;
using ArGeTesvikTool.Entities.Concrete.RdCenter;

namespace ArGeTesvikTool.DataAccess.Abstract.RdCenter
{
    public interface IRdCenterPhysicalAreaDal : IEntityRepository<RdCenterPhysicalAreaDto>
    {
        //custom operations for business info class, that should be written here. like; store procedure or join query
    }
}
