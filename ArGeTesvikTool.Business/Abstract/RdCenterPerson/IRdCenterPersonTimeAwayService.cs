using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterPerson
{
    public interface IRdCenterPersonTimeAwayService
    {
        void Add(RdCenterPersonTimeAwayDto rdCenterPersoTimeAway);
        void AddList(List<RdCenterPersonTimeAwayDto> rdCenterPersoTimeAwayList);
        void Update(RdCenterPersonTimeAwayDto rdCenterPersoTimeAway);
        void Delete(int id);
        RdCenterPersonTimeAwayDto GetById(int id);
        List<RdCenterPersonTimeAwayDto> GetAllByYear(int year);
    }
}
