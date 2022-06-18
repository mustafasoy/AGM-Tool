using ArGeTesvikTool.Business.Abstract.Report;
using ArGeTesvikTool.DataAccess.Abstract.Report;
using ArGeTesvikTool.Entities.Concrete.Report;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.Report
{
    public class TeleworkingManager : ITeleworkingService
    {
        private readonly ITeleworkingDal _teleworking;

        public TeleworkingManager(ITeleworkingDal teleworking)
        {
            _teleworking = teleworking;
        }

        public void AddList(List<TeleworkingDto> teleworkingList)
        {
            _teleworking.AddList(teleworkingList);
        }

        public List<TeleworkingDto> GetByYearByMonth(int year, int month)
        {
            return _teleworking.GetList(x => x.Year == year && x.Month == month);
        }
    }
}
