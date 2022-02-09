using ArGeTesvikTool.Business.Abstract.RdCenterPerson;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;

namespace ArGeTesvikTool.Business.Concrete.RdCenterPerson
{
    public class RdCenterPersonRewardManager : IRdCenterPersonRewardService
    {
        private readonly IRdCenterPersonRewardDal _personRewardDal;

        public RdCenterPersonRewardManager(IRdCenterPersonRewardDal personRewardDal)
        {
            _personRewardDal = personRewardDal;
        }

        public void Add(RdCenterPersonRewardDto rdCenterPersoReward)
        {
            _personRewardDal.Add(rdCenterPersoReward);
        }

        public void Update(RdCenterPersonRewardDto rdCenterPersoReward)
        {
            _personRewardDal.Update(rdCenterPersoReward);
        }

        public void Delete(int id)
        {
            _personRewardDal.Delete(new RdCenterPersonRewardDto { Id = id });
        }

        public RdCenterPersonRewardDto GetByYear(int year)
        {
            return _personRewardDal.Get(x => x.Year == year);
        }
    }
}
