using ArGeTesvikTool.Core.Data_Access;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;

namespace ArGeTesvikTool.DataAccess.Abstract.RdCenterTech
{
    public interface IRdCenterTechProjectManagementDal : IEntityRepository<RdCenterTechProjectManagementDto>
    {
        //custom operations that should be written here. like; store procedure or join query
    }
}
