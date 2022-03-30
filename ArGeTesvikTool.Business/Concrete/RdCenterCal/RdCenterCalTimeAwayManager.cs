using ArGeTesvikTool.Business.Abstract.RdCenterCal;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenterCal
{
    public class RdCenterCalTimeAwayManager : IRdCenterCalTimeAwayService
    {
        private readonly IRdCenterCalTimeAwayDal _timeAway;

        public RdCenterCalTimeAwayManager(IRdCenterCalTimeAwayDal timeAway)
        {
            _timeAway = timeAway;
        }

        public void Add(RdCenterCalTimeAwayDto rdCenterCalTimeAway)
        {
            _timeAway.Add(rdCenterCalTimeAway);
        }

        public void Update(RdCenterCalTimeAwayDto rdCenterCalTimeAway)
        {
            _timeAway.Update(rdCenterCalTimeAway);
        }

        public void Delete(int id)
        {
            _timeAway.Delete(new RdCenterCalTimeAwayDto { Id = id });
        }

        public RdCenterCalTimeAwayDto GetById(int id)
        {
            return _timeAway.Get(x => x.Id == id);
        }

        public List<RdCenterCalTimeAwayDto> GetAll()
        {
            return _timeAway.GetList();
        }
    }
}
