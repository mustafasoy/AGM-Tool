using ArGeTesvikTool.Business.Abstract.RdCenterPerformance;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterPerformance;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerformance;
using System;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenterPerformance
{
    public class RdCenterPerformanceProjectManager : IRdCenterPerformanceProjectService
    {
        private readonly IRdCenterPerformanceProjectDal _rdCenterPerformanceProject;

        public RdCenterPerformanceProjectManager(IRdCenterPerformanceProjectDal rdCenterPerformanceProject)
        {
            _rdCenterPerformanceProject = rdCenterPerformanceProject;
        }

        public void Add(RdCenterPerformanceProjectDto rdCenterPerformanceProject)
        {
            _rdCenterPerformanceProject.Add(rdCenterPerformanceProject);
        }

        public void Update(RdCenterPerformanceProjectDto rdCenterPerformanceProject)
        {
            _rdCenterPerformanceProject.Update(rdCenterPerformanceProject);
        }

        public void Delete(int id)
        {
            _rdCenterPerformanceProject.Delete(new RdCenterPerformanceProjectDto { Id = id });
        }

        public RdCenterPerformanceProjectDto GetById(int id)
        {
            return _rdCenterPerformanceProject.Get(x => x.Id == id);
        }

        public List<RdCenterPerformanceProjectDto> GetAllByYear(int year)
        {
            return _rdCenterPerformanceProject.GetList(x => x.Year == year);
        }
    }
}
