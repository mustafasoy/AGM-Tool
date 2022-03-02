using ArGeTesvikTool.Core.Data_Access.EntityFramework;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;

namespace ArGeTesvikTool.DataAccess.Concrete.EntityFramework.RdCenterTech
{
    public class EfRdCenterTechProjectDal : EfEntityRepositoryBase<RdCenterTechOngoingProjectDto, AGMDbContext>, IRdCenterTechProjectDal
    {
    }
}
