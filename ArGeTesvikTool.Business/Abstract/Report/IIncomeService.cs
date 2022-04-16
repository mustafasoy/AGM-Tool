using ArGeTesvikTool.Entities.Concrete.Report;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.Report
{
    public interface IIncomeService
    {
        IncomeDto GetByYearByMonth(int year, int month);
        void AddList(List<IncomeDto> incomeList);
    }
}
