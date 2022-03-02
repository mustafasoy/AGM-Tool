using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterTech
{
    public interface IRdCenterTechProjectService
    {
        void Add(RdCenterTechOngoingProjectDto rdCenterTechOngoingProject);
        void Update(RdCenterTechOngoingProjectDto rdCenterTechOngoingProject);
        void Delete(int id);
        RdCenterTechOngoingProjectDto GetById(int id);
        List<RdCenterTechOngoingProjectDto> GetAllByYear(int year);
    }
}
