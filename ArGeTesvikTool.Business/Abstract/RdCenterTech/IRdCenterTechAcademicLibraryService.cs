using ArGeTesvikTool.Entities.Concrete.RdCenterTech;

namespace ArGeTesvikTool.Business.Abstract.RdCenterTech
{
    public interface IRdCenterTechAcademicLibraryService
    {
        void Add(RdCenterTechAcademicLibraryDto rdCenterTechAcademicLibrary);
        void Update(RdCenterTechAcademicLibraryDto rdCenterTechAcademicLibrary);
        void Delete(int id);
        RdCenterTechAcademicLibraryDto GetByYear(int year);
    }
}
