using ArGeTesvikTool.Entities.Concrete.Report;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.Report
{
    public interface ISocialSecurityService
    {
        SocialSecurityDto GetByYearByMonth(int year, int month);
        void AddList(List<SocialSecurityDto> ssiList);
    }
}
