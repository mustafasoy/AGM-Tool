using ArGeTesvikTool.Business.Abstract.RdCenterTech;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenterTech
{
    public class RdCenterTechProjectManager : IRdCenterTechProjectService
    {
        private readonly IRdCenterTechProjectDal _rdCenterTechOngoingProject;

        public RdCenterTechProjectManager(IRdCenterTechProjectDal rdCenterTechOngoingProject)
        {
            _rdCenterTechOngoingProject = rdCenterTechOngoingProject;
        }

        public void Add(RdCenterTechOngoingProjectDto rdCenterTechOngoingProject)
        {
            _rdCenterTechOngoingProject.Add(rdCenterTechOngoingProject);
        }

        public void Update(RdCenterTechOngoingProjectDto rdCenterTechOngoingProject)
        {
            _rdCenterTechOngoingProject.Update(rdCenterTechOngoingProject);
        }

        public void Delete(int id)
        {
            _rdCenterTechOngoingProject.Delete(new RdCenterTechOngoingProjectDto { Id = id });
        }

        public RdCenterTechOngoingProjectDto GetById(int id)
        {
            return _rdCenterTechOngoingProject.Get(x => x.Id == id);
        }

        public List<RdCenterTechOngoingProjectDto> GetAllByYear(int year)
        {
            return _rdCenterTechOngoingProject.GetList(x => x.Year == year && x.ProjectStatu == ProjectStatu.Iptal);
        }
    }
}
