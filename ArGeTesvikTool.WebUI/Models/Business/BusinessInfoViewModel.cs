using ArGeTesvikTool.Entities.Concrete.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArGeTesvikTool.WebUI.Models.Business
{
    public class BusinessInfoViewModel
    {
        public BusinessInfoDto BusinessInfo { get; set; }
        public List<string> isSME { get; set; }
    }
}
