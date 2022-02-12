using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterTech
{
    public interface IRdCenterTechProjectManagementService
    {
        void Add(RdCenterTechProjectManagementDto rdCenterTechProjectManagement);
        void Update(RdCenterTechProjectManagementDto rdCenterTechProjectManagement);
        void Delete(int id);
        RdCenterTechProjectManagementDto GetById(int id);
        List<RdCenterTechProjectManagementDto> GetAllByYear(int year);
    }
}
