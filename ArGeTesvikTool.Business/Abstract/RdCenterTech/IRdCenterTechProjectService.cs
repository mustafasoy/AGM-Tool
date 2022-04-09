using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterTech
{
    public interface IRdCenterTechProjectService
    {
        void Add(RdCenterTechProjectDto rdCenterTechProject);
        void Update(RdCenterTechProjectDto rdCenterTechProject);
        void Delete(int id);
        RdCenterTechProjectDto GetById(int id);
        List<RdCenterTechProjectDto> GetAllByYearStatu(int year, string projectStatu);
        List<RdCenterTechProjectDto> GetAllProjectName();
    }
}
