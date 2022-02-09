using ArGeTesvikTool.Core.Data_Access.EntityFramework;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;

namespace ArGeTesvikTool.DataAccess.Concrete.EntityFramework.RdCenterTech
{
    public class EfRdCenterTechAcademicLibraryDal : EfEntityRepositoryBase<RdCenterTechAcademicLibraryDto, AGMDbContext>, IRdCenterTechAcademicLibraryDal
    {
    }
}
