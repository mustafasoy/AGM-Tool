using ArGeTesvikTool.Core.Data_Access.EntityFramework;
using ArGeTesvikTool.DataAccess.Abstract;
using ArGeTesvikTool.Entities.Concrete.Business;

namespace ArGeTesvikTool.DataAccess.Concrete.EntityFramework.Business
{
    public class EfBusinessInfoDal : EfEntityRepositoryBase<BusinessInfoDto, AGMDbContext>, IBusinessInfoDal
    {
    }
}
