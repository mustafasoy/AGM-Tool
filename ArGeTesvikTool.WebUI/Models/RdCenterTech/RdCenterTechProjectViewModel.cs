using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.RdCenterTech
{
    public class RdCenterTechProjectViewModel
    {
        public int RowNo { get; set; }
        public RdCenterTechProjectDto NewProject { get; set; }
        public List<IFormFile> ProjectFile { get; set; }
        public List<IFormFile> IncomeFile { get; set; }
        public List<IFormFile> DocumentFile { get; set; }
        public List<RdCenterTechProjectDto> ProjectList { get; set; }
    }
}
