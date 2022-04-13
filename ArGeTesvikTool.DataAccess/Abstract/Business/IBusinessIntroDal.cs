using ArGeTesvikTool.Core.Data_Access;
using ArGeTesvikTool.Entities.Concrete.Business;

namespace ArGeTesvikTool.DataAccess.Abstract
{
    public interface IBusinessIntroDal : IEntityRepository<BusinessIntroDto>
    {
        //custom operations that should be written here. like; store procedure or join query
    }
}
