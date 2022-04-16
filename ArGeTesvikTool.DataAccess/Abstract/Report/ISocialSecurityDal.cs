using ArGeTesvikTool.Core.Data_Access;
using ArGeTesvikTool.Entities.Concrete.Report;

namespace ArGeTesvikTool.DataAccess.Abstract.Report
{
    public interface ISocialSecurityDal : IEntityRepository<SocialSecurityDto>
    {
        //custom operations that should be written here. like; store procedure or join query
    }
}
