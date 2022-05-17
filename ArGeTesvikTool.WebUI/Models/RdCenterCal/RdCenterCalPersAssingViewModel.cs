using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterCal
{
    public class RdCenterCalPersAssingViewModel
    {
        public List<RdCenterCalPersonnelList> AllPersonnel { get; set; }
        public List<SelectListItem> AllProject { get; set; }
    }
}
