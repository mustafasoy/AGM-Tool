using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterTech
{
    public interface IRdCenterTechCollaborationService
    {
        void Add(RdCenterTechCollaborationDto rdCenterTechCollaboration);
        void Update(RdCenterTechCollaborationDto rdCenterTechCollaboration);
        void Delete(int id);
        RdCenterTechCollaborationDto GetById(int id);
        List<RdCenterTechCollaborationDto> GetAll();
    }
}
