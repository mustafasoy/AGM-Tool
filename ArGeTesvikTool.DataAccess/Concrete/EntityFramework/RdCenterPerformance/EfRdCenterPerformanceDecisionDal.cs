using ArGeTesvikTool.Core.Data_Access.EntityFramework;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterPerformance;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerformance;

namespace ArGeTesvikTool.DataAccess.Concrete.EntityFramework.RdCenterPerformance
{
    public class EfRdCenterPerformanceDecisionDal : EfEntityRepositoryBase<RdCenterPerformanceDecisionDto, AGMDbContext>, IRdCenterPerformanceDecisionDal
    {
    }
}
