using ArGeTesvikTool.Business.Abstract.RdCenterTech;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenterTech
{
    public class RdCenterTechProjectManagementManager : IRdCenterTechProjectManagementService
    {
        private readonly IRdCenterTechProjectManagementDal _rdCenterTechProject;

        public RdCenterTechProjectManagementManager(IRdCenterTechProjectManagementDal rdCenterTechProject)
        {
            _rdCenterTechProject = rdCenterTechProject;
        }

        public void Add(RdCenterTechProjectManagementDto rdCenterTechProjectManagement)
        {
            _rdCenterTechProject.Add(rdCenterTechProjectManagement);
        }

        public void Update(RdCenterTechProjectManagementDto rdCenterTechProjectManagement)
        {
            _rdCenterTechProject.Update(rdCenterTechProjectManagement);
        }

        public void Delete(int id)
        {
            _rdCenterTechProject.Delete(new RdCenterTechProjectManagementDto { Id = id });
        }

        public RdCenterTechProjectManagementDto GetById(int id)
        {
            return _rdCenterTechProject.Get(x => x.Id == id);
        }

        public List<RdCenterTechProjectManagementDto> GetAllByYear(int year)
        {
            return _rdCenterTechProject.GetList(x => x.Year == year);
        }
    }
}
