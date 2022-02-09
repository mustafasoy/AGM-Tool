using ArGeTesvikTool.Business.Abstract.RdCenterTech;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System;

namespace ArGeTesvikTool.Business.Concrete.RdCenterTech
{
    public class RdCenterTechAcademicLibraryManager : IRdCenterTechAcademicLibraryService
    {
        private readonly IRdCenterTechAcademicLibraryDal _academicLibraryDal;

        public RdCenterTechAcademicLibraryManager(IRdCenterTechAcademicLibraryDal academicLibraryDal)
        {
            _academicLibraryDal = academicLibraryDal;
        }

        public void Add(RdCenterTechAcademicLibraryDto rdCenterTechAcademicLibrary)
        {
            _academicLibraryDal.Add(rdCenterTechAcademicLibrary);
        }

        public void Update(RdCenterTechAcademicLibraryDto rdCenterTechAcademicLibrary)
        {
            _academicLibraryDal.Update(rdCenterTechAcademicLibrary);
        }

        public void Delete(int id)
        {
            _academicLibraryDal.Delete(new RdCenterTechAcademicLibraryDto { Id = id });
        }

        public RdCenterTechAcademicLibraryDto GetByYear(int year)
        {
            return _academicLibraryDal.Get(x => x.Year == year);
        }
    }
}
