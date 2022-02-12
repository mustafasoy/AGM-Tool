using ArGeTesvikTool.Entities.Concrete.Business;

namespace ArGeTesvikTool.Business.Abstract.Business
{
    public interface IStrategyService
    {
        void Add(StrategyDto strategy);
        void Update(StrategyDto strategy);
        StrategyDto GetByYear(int year);
    }
}
