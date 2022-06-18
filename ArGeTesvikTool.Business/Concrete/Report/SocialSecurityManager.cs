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

        public void AddList(List<SocialSecurityDto> ssiList)
        {
            _socialSecurity.AddList(ssiList);
        }

        public void DeleteList(List<SocialSecurityDto> ssiList)
        {
            _socialSecurity.DeleteList(ssiList);
        }

        public List<SocialSecurityDto> GetByYearByMonth(int year, int month)
        {
            return _socialSecurity.GetList(x => x.Year == year && x.Month == month);
        }
    }
}
