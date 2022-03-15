using ArGeTesvikTool.Core.Data_Access;
using ArGeTesvikTool.Entities.Concrete.Index;

namespace ArGeTesvikTool.DataAccess.Abstract.Index
{
    public interface INewDataDal : IEntityRepository<NewDataDto>
    {
        //custom operations for business info class, that should be written here. like; store procedure or join query
    }
}