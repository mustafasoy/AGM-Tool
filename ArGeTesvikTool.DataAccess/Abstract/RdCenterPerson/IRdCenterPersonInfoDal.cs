using ArGeTesvikTool.Core.Data_Access;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;

namespace ArGeTesvikTool.DataAccess.Abstract.RdCenterPerson
{
    public interface IRdCenterPersonInfoDal : IEntityRepository<RdCenterPersonInfoDto>
    {
        //custom operations that should be written here. like; store procedure or join query
    }
}
