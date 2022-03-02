using ArGeTesvikTool.Entities.Concrete.RdCenter;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenter
{
    public interface IRdCenterPhysicalAreaService
    {
        void Add(RdCenterPhysicalAreaDto rdPhysicalArea);
        void Update(RdCenterPhysicalAreaDto rdPhysicalArea);
        void Delete(int id);
        RdCenterPhysicalAreaDto GetById(int id);
        List<RdCenterPhysicalAreaDto> GetAllByYear(int year);
    }
}
