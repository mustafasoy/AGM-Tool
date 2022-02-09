using ArGeTesvikTool.Business.Abstract.RdCenterTech;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenterTech
{
    public class RdCenterTechAttendedEventManager : IRdCenterTechAttendedEventService
    {
        private readonly IRdCenterTechAttendedEventDal _attendedEventDal;

        public RdCenterTechAttendedEventManager(IRdCenterTechAttendedEventDal attendedEventDal)
        {
            _attendedEventDal = attendedEventDal;
        }

        public void Add(RdCenterTechAttendedEventDto rdCenterTechAttended)
        {
            _attendedEventDal.Add(rdCenterTechAttended);
        }

        public void Update(RdCenterTechAttendedEventDto rdCenterTechAttended)
        {
            _attendedEventDal.Update(rdCenterTechAttended);
        }

        public void Delete(int id)
        {
            _attendedEventDal.Delete(new RdCenterTechAttendedEventDto { Id = id });
        }

        public RdCenterTechAttendedEventDto GetById(int id)
        {
            return _attendedEventDal.Get(x => x.Id == id);
        }

        public List<RdCenterTechAttendedEventDto> GetAll()
        {
            return _attendedEventDal.GetList();
        }
    }
}
