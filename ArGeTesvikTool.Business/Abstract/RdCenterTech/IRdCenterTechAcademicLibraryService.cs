using ArGeTesvikTool.Entities.Concrete.RdCenterTech;

namespace ArGeTesvikTool.Business.Abstract.RdCenterTech
{
    public interface IRdCenterTechAcademicLibraryService
    {
        void Add(RdCenterTechAcademicLibraryDto rdCenterTechAcademicLibrary);
        void Update(RdCenterTechAcademicLibraryDto rdCenterTechAcademicLibrary);
        RdCenterTechAcademicLibraryDto GetByYear(int year);
    }
}
