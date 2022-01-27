using ArGeTesvikTool.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Entities.Concrete.RdCenter
{
    public class RdCenterRewardDto : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
