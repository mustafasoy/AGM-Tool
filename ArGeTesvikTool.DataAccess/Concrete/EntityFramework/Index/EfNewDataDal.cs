using ArGeTesvikTool.Core.Data_Access.EntityFramework;
using ArGeTesvikTool.DataAccess.Abstract.Index;
using ArGeTesvikTool.Entities.Concrete.Index;

namespace ArGeTesvikTool.DataAccess.Concrete.EntityFramework.Index
{
    public class EfNewDataDal : EfEntityRepositoryBase<NewDataDto, AGMDbContext>, INewDataDal
    {
    }
}
