using ArGeTesvikTool.Entities.Concrete.RdCenterPerformance;

namespace ArGeTesvikTool.Business.Abstract.RdCenterPerformance
{
    public interface IRdCenterPerformanceDecisionService
    {
        void Add(RdCenterPerformanceDecisionDto businessInfo);
        void Update(RdCenterPerformanceDecisionDto businessInfo);
        RdCenterPerformanceDecisionDto GetByYear(int year);
    }
}
