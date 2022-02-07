using ArGeTesvikTool.Entities.Concrete.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArGeTesvikTool.WebUI.Models.Business
{
    public class ShareholderViewModel
    {
        public ShareholdersDto NewShareholder { get; set; }
        public List<ShareholdersDto> Shareholder { get; set; }
    }
}
