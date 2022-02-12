using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;

namespace ArGeTesvikTool.Business.Abstract.RdCenterPerson
{
    public interface IRdCenterPersonRewardService
    {
        void Add(RdCenterPersonRewardDto rdCenterPersoReward);
        void Update(RdCenterPersonRewardDto rdCenterPersoReward);
        RdCenterPersonRewardDto GetByYear(int year);
    }
}
