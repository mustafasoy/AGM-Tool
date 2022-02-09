using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterPerson
{
    public class RdCenterPersonViewModel
    {
        public RdCenterPersonInfoDto NewPersonnelInfo { get; set; }
        public List<RdCenterPersonInfoDto> PersonInfoList { get; set; }
    }
}
