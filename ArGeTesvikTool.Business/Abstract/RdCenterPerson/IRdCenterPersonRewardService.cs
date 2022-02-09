using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;

namespace ArGeTesvikTool.Business.Abstract.RdCenterPerson
{
    public interface IRdCenterPersonRewardService
    {
        void Add(RdCenterPersonRewardDto rdCenterPersoReward);
        void Update(RdCenterPersonRewardDto rdCenterPersoReward);
        void Delete(int id);
        RdCenterPersonRewardDto GetByYear(int year);
    }
}
