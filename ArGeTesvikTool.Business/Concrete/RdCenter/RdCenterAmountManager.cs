using ArGeTesvikTool.Business.Abstract.RdCenter;
using ArGeTesvikTool.DataAccess.Abstract.RdCenter;
using ArGeTesvikTool.Entities.Concrete.RdCenter;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenter
{
    public class RdCenterAmountManager: IRdCenterAmountService
    {
        private readonly IRdCenterAmountDal _amount;

        public RdCenterAmountManager(IRdCenterAmountDal amount)
        {
            _amount = amount;
        }

        public void Add(RdCenterAmountDto rdCenterAmount)
        {
            _amount.Add(rdCenterAmount);
        }

        public void Update(RdCenterAmountDto rdCenterAmount)
        {
            _amount.Update(rdCenterAmount);
        }

        public void Delete(int id)
        {
            _amount.Delete(new RdCenterAmountDto { Id = id });
        }

        public RdCenterAmountDto GetById(int id)
        {
            return _amount.Get(x => x.Id == id);
        }

        public List<RdCenterAmountDto> GetListByYear(int year)
        {
            return _amount.GetList(x => x.Year == year);
        }
    }
}
