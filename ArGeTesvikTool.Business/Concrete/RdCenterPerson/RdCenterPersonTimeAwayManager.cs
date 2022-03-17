using ArGeTesvikTool.Business.Abstract.RdCenterPerson;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenterPerson
{
    public class RdCenterPersonTimeAwayManager : IRdCenterPersonTimeAwayService
    {

        private readonly IRdCenterPersonTimeAwayDal _rdCenterPersonTimeAway;
        public RdCenterPersonTimeAwayManager(IRdCenterPersonTimeAwayDal rdCenterPersonTimeAway)
        {
            _rdCenterPersonTimeAway = rdCenterPersonTimeAway;
        }

        public void Add(RdCenterPersonTimeAwayDto rdCenterPersoTimeAway)
        {
            _rdCenterPersonTimeAway.Add(rdCenterPersoTimeAway);
        }

        public void AddList(List<RdCenterPersonTimeAwayDto> rdCenterPersoTimeAwayList)
        {
            _rdCenterPersonTimeAway.AddList(rdCenterPersoTimeAwayList);
        }

        public void Update(RdCenterPersonTimeAwayDto rdCenterPersoTimeAway)
        {
            _rdCenterPersonTimeAway.Update(rdCenterPersoTimeAway);
        }

        public void Delete(int id)
        {
            _rdCenterPersonTimeAway.Delete(new RdCenterPersonTimeAwayDto { Id = id });
        }

        public RdCenterPersonTimeAwayDto GetById(int id)
        {
            return _rdCenterPersonTimeAway.Get(x => x.Id == id);
        }

        public List<RdCenterPersonTimeAwayDto> GetAllByYear(int year)
        {
            return _rdCenterPersonTimeAway.GetList(x => x.Year == year);
        }
    }
}
