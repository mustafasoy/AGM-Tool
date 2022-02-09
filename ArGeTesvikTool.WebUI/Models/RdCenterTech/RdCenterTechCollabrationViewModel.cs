using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterTech
{
    public class RdCenterTechCollabrationViewModel
    {
        public RdCenterTechCollaborationDto NewCollaboration { get; set; }
        public List<RdCenterTechCollaborationDto> CollaborationList { get; set; }
    }
}
