using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterTech
{
    public interface IRdCenterTechSoftwareService
    {
        void Add(RdCenterTechSoftwareDto rdCenterTechSoftware);
        void Update(RdCenterTechSoftwareDto rdCenterTechSoftware);
        void Delete(int id);
        RdCenterTechSoftwareDto GetById(int id);
        List<RdCenterTechSoftwareDto> GetAllByYear(int year);
    }
}
