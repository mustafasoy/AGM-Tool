using ArGeTesvikTool.Core.Data_Access;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerformance;

namespace ArGeTesvikTool.DataAccess.Abstract.RdCenterPerformance
{
    public interface IRdCenterPerformanceProjectDal : IEntityRepository<RdCenterPerformanceProjectDto>
    {
        //custom operations for business info class, that should be written here. like; store procedure or join query
    }
}
