using ArGeTesvikTool.Core.Data_Access.EntityFramework;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;

namespace ArGeTesvikTool.DataAccess.Concrete.EntityFramework.RdCenterPerson
{
    public class EfRdCenterPersonInfoDal : EfEntityRepositoryBase<RdCenterPersonInfoDto, AGMDbContext>, IRdCenterPersonInfoDal
    {
    }
}
