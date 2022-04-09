using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterCal
{
    public class RdCenterCalManagerEntryViewModel
    {
        public RdCenterCalManagerEntryDto EntryInfo { get; set; }
        public List<RdCenterCalManagerEntryDto> EntryList { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
