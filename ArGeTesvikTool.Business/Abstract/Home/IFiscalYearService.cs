using ArGeTesvikTool.Entities.Concrete;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.Home
{
    public interface IFiscalYearService
    {
        void Add(FiscalYearDto fiscalYear);

        List<FiscalYearDto> GetYearList();
    }
}
