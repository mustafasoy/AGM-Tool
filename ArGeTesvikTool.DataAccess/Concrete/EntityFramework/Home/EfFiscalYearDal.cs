using ArGeTesvikTool.Core.Data_Access.EntityFramework;
using ArGeTesvikTool.DataAccess.Abstract;
using ArGeTesvikTool.Entities.Concrete;

namespace ArGeTesvikTool.DataAccess.Concrete.EntityFramework
{
    public class EfFiscalYearDal : EfEntityRepositoryBase<FiscalYearDto, AGMDbContext>, IFiscalYearDal
    {
    }
}
