using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterTech
{
    public interface IRdCenterTechAttendedEventService
    {
        void Add(RdCenterTechAttendedEventDto rdCenterTechAttended);
        void Update(RdCenterTechAttendedEventDto rdCenterTechAttended);
        void Delete(int id);
        RdCenterTechAttendedEventDto GetById(int id);
        List<RdCenterTechAttendedEventDto> GetAll();
    }
}
