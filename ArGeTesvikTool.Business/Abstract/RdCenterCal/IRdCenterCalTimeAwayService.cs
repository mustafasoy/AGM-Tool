using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterCal
{
    public interface IRdCenterCalTimeAwayService
    {
        void Add(RdCenterCalTimeAwayDto rdCenterCalTimeAway);
        void Update(RdCenterCalTimeAwayDto rdCenterCalTimeAway);
        void Delete(int id);
        RdCenterCalTimeAwayDto GetById(int id);
        List<RdCenterCalTimeAwayDto> GetAll();
    }
}
