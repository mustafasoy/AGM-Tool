using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterTech
{
    public class RdCenterTechMentorInfoViewModel
    {
        public RdCenterTechMentorInfoDto NewMentorInfo { get; set; }
        public List<RdCenterTechMentorInfoDto> MentorInfoList { get; set; }
    }
}
