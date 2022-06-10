using ArGeTesvikTool.Business.Abstract.RdCenterPerformance;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterPerformance;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerformance;

namespace ArGeTesvikTool.Business.Concrete.RdCenterPerformance
{
    public class RdCenterPerformanceDecisionManager : IRdCenterPerformanceDecisionService
    {
        private readonly IRdCenterPerformanceDecisionDal _decisionDal;

        public RdCenterPerformanceDecisionManager(IRdCenterPerformanceDecisionDal decisionDal)
        {
            _decisionDal = decisionDal;
        }

        public void Add(RdCenterPerformanceDecisionDto decision)
        {
            _decisionDal.Add(decision);
        }

        public void Update(RdCenterPerformanceDecisionDto decision)
        {
            _decisionDal.Update(decision);
        }

        public RdCenterPerformanceDecisionDto GetByYear(int year)
        {
            return _decisionDal.Get(x => x.Year == year);
        }
    }
}
