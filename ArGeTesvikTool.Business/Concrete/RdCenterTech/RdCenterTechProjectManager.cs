using ArGeTesvikTool.Business.Abstract.RdCenterTech;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArGeTesvikTool.Business.Concrete.RdCenterTech
{
    public class RdCenterTechProjectManager : IRdCenterTechProjectService
    {
        private readonly IRdCenterTechProjectDal _rdCenterTechProject;

        public RdCenterTechProjectManager(IRdCenterTechProjectDal rdCenterTechProject)
        {
            _rdCenterTechProject = rdCenterTechProject;
        }

        public void Add(RdCenterTechProjectDto rdCenterTechProject)
        {
            _rdCenterTechProject.Add(rdCenterTechProject);
        }

        public void Update(RdCenterTechProjectDto rdCenterTechProject)
        {
            _rdCenterTechProject.Update(rdCenterTechProject);
        }

        public void Delete(int id)
        {
            _rdCenterTechProject.Delete(new RdCenterTechProjectDto { Id = id });
        }

        public RdCenterTechProjectDto GetById(int id)
        {
            return _rdCenterTechProject.Get(x => x.Id == id);
        }

        public List<RdCenterTechProjectDto> GetAllByYearStatu(int year, string projectStatus)
        {
            return _rdCenterTechProject.GetList(x => x.Year == year &&
                                                     x.ProjectStatu == (ProjectStatu)Enum.Parse(typeof(ProjectStatu), projectStatus));
        }

        public List<RdCenterTechProjectDto> GetAllProjectName()
        {
            return _rdCenterTechProject.GetList()
                            .Select(x=> new RdCenterTechProjectDto
                            {
                                ProjectCode = x.ProjectCode,
                                ProjectName = x.ProjectName
                            }).ToList();
        }
    }
}
