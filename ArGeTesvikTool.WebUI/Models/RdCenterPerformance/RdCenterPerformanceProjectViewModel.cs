using ArGeTesvikTool.Entities.Concrete.RdCenterPerformance;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterPerformance
{
    public class RdCenterPerformanceProjectViewModel
    {
        public RdCenterPerformanceProjectDto NewProjectInfo { get; set; }
        public List<RdCenterPerformanceProjectDto> ProjectInfoList { get; set; }
    }
}
