using ArGeTesvikTool.Business.Abstract.Report;
using ArGeTesvikTool.DataAccess.Abstract.Report;
using ArGeTesvikTool.Entities.Concrete.Report;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.Report
{
    public class IncomeManager : IIncomeService
    {
        private readonly IIncomeDal _income;

        public IncomeManager(IIncomeDal income)
        {
            _income = income;
        }
        public IncomeDto GetByYearByMonth(int year, int month)
        {
            return _income.Get(x => x.Year == year && x.Month == month);
        }

        public void AddList(List<IncomeDto> incomeList)
        {
            _income.AddList(incomeList);
        }
    }
}
