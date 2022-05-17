using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenterCal
{
    public interface IRdCenterCalPersAssingService
    {
        void AddList(List<RdCenterCalPersAssingDto> rdCenterCalPersAssingList);
        void UpdateList(List<RdCenterCalPersAssingDto> rdCenterCalPersAssingList);
        List<RdCenterCalPersAssingDto> GetByYearProjectCode(int year, string projectCode);
    }
}
