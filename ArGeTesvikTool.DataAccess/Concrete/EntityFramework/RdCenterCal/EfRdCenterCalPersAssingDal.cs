using ArGeTesvikTool.Core.Data_Access.EntityFramework;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;

namespace ArGeTesvikTool.DataAccess.Concrete.EntityFramework.RdCenterCal
{
    public class EfRdCenterCalPersAssingDal : EfEntityRepositoryBase<RdCenterCalPersAssingDto, AGMDbContext>, IRdCenterCalPersAssingDal
    {
    }
}
