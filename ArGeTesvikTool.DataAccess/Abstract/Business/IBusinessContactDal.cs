using ArGeTesvikTool.Core.Data_Access;
using ArGeTesvikTool.Entities.Concrete.Business;

namespace ArGeTesvikTool.DataAccess.Abstract
{
    public interface IBusinessContactDal : IEntityRepository<BusinessContactDto>
    {
        //custom operations that should be written here. like; store procedure or join query
    }
}
