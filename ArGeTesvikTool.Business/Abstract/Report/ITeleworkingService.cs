using ArGeTesvikTool.Entities.Concrete.Report;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.Report
{
    public interface ITeleworkingService
    {
        List<TeleworkingDto> GetByYearByMonth(int year, int month);
        void AddList(List<TeleworkingDto> teleworkingList);
    }
}
