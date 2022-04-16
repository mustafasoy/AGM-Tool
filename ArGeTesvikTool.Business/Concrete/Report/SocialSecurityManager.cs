using ArGeTesvikTool.Business.Abstract.Report;
using ArGeTesvikTool.DataAccess.Abstract.Report;
using ArGeTesvikTool.Entities.Concrete.Report;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.Report
{
    public class SocialSecurityManager : ISocialSecurityService
    {
        private readonly ISocialSecurityDal _socialSecurity;

        public SocialSecurityManager(ISocialSecurityDal socialSecurity)
        {
            _socialSecurity = socialSecurity;
        }

        public SocialSecurityDto GetByYearByMonth(int year, int month)
        {
            return _socialSecurity.Get(x => x.Year == year && x.Month == month);
        }

        public void AddList(List<SocialSecurityDto> ssiList)
        {
            _socialSecurity.AddList(ssiList);
        }
    }
}
