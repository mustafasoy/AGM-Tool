using ArGeTesvikTool.Entities.Concrete.RdCenter;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.RdCenter
{
    public interface IRdCenterDiscountService
    {
        void Add(RdCenterDiscountDto rdCenterDiscount);
        void Update(RdCenterDiscountDto rdCenterDiscount);
        void Delete(int id);
        RdCenterDiscountDto GetById(int id);
        List<RdCenterDiscountDto> GetListByYear(int year);
    }
}
