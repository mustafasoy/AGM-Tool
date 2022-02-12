using ArGeTesvikTool.Business.Abstract.Business;
using ArGeTesvikTool.DataAccess.Abstract.Business;
using ArGeTesvikTool.Entities.Concrete.Business;
using System;

namespace ArGeTesvikTool.Business.Concrete.Business
{
    public class StrategyManager : IStrategyService
    {
        private readonly IStrategyDal _strategyDal;

        public StrategyManager(IStrategyDal strategyDal)
        {
            _strategyDal = strategyDal;
        }

        public void Add(StrategyDto strategy)
        {
            _strategyDal.Add(strategy);
        }

        public void Update(StrategyDto strategy)
        {
            _strategyDal.Update(strategy);
        }

        public StrategyDto GetByYear(int year)
        {
            return _strategyDal.Get(x => x.Year == year);
        }
    }
}
