using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterTech
{
    public class RdCenterTechCompletedProjectViewModel
    {
        public int RowNo { get; set; }
        public List<RdCenterTechCompletedProjectDto> ProjectList { get; set; }
    }
}
