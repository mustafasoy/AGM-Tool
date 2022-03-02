using ArGeTesvikTool.Entities.Concrete.RdCenter;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenter
{
    public interface IRdCenterAmountService
    {
        void Add(RdCenterAmountDto rdCenterAmount);
        void Update(RdCenterAmountDto rdCenterAmount);
        void Delete(int id);
        RdCenterAmountDto GetById(int id);
        List<RdCenterAmountDto> GetListByYear(int year);
    }
}
