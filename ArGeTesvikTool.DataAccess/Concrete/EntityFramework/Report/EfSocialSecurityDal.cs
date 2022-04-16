using ArGeTesvikTool.Core.Data_Access.EntityFramework;
using ArGeTesvikTool.DataAccess.Abstract.Report;
using ArGeTesvikTool.Entities.Concrete.Report;

namespace ArGeTesvikTool.DataAccess.Concrete.EntityFramework.Report
{
    public class EfSocialSecurityDal : EfEntityRepositoryBase<SocialSecurityDto, AGMDbContext>, ISocialSecurityDal
    {
    }
}
