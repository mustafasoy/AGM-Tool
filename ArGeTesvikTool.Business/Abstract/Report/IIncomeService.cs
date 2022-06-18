using ArGeTesvikTool.Entities.Concrete.Report;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.Report
{
    public interface IIncomeService
    {
        List<IncomeDto> GetByYearByMonth(int year, int month);
        void AddList(List<IncomeDto> incomeList);
        void DeleteList(List<IncomeDto> incomeList);
    }
}
