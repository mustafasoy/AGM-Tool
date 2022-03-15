using ArGeTesvikTool.Business.Abstract.RdCenter;
using ArGeTesvikTool.DataAccess.Abstract.RdCenter;
using ArGeTesvikTool.Entities.Concrete.RdCenter;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenter
{
    public class RdCenterDiscountManager : IRdCenterDiscountService
    {
        private readonly IRdCenterDiscountDal _discount;

        public RdCenterDiscountManager(IRdCenterDiscountDal discount)
        {
            _discount = discount;
        }

        public void Add(RdCenterDiscountDto rdCenterDiscount)
        {
            _discount.Add(rdCenterDiscount);
        }

        public void Update(RdCenterDiscountDto rdCenterDiscount)
        {
            _discount.Update(rdCenterDiscount);
        }

        public void Delete(int id)
        {
            _discount.Delete(new RdCenterDiscountDto { Id = id });
        }

        public RdCenterDiscountDto GetById(int id)
        {
            return _discount.Get(x => x.Id == id);
        }

        public List<RdCenterDiscountDto> GetAllByYear(int year)
        {
            return _discount.GetList(x => x.Year == year);
        }
    }
}
