using ArGeTesvikTool.Core.Data_Access;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;

namespace ArGeTesvikTool.DataAccess.Abstract.RdCenterCal
{
    public interface IRdCenterCalPersonnelDal : IEntityRepository<RdCenterCalPersonnelInfoDto>
    {
        //custom operations for business info class, that should be written here. like; store procedure or join query
    }
}
