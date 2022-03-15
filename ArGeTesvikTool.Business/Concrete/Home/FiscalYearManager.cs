using ArGeTesvikTool.Business.Abstract.Home;
using ArGeTesvikTool.DataAccess.Abstract;
using ArGeTesvikTool.Entities.Concrete;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.Home
{
    public class FiscalYearManager:IFiscalYearService
    {
        private readonly IFiscalYearDal _fiscalYear;

        public FiscalYearManager(IFiscalYearDal fiscalYear)
        {
            _fiscalYear = fiscalYear;
        }

        public void Add(FiscalYearDto fiscalYear)
        {
            _fiscalYear.Add(fiscalYear);
        }

        public List<FiscalYearDto> GetYearList()
        {
            return _fiscalYear.GetList();
        }
    }
}
