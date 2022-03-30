using ArGeTesvikTool.Business.Abstract.RdCenterCal;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenterCal
{
    public class RdCenterCalPersAssingManager : IRdCenterCalPersAssingService
    {
        private readonly IRdCenterCalPersAssingDal _persAssing;

        public RdCenterCalPersAssingManager(IRdCenterCalPersAssingDal persAssing)
        {
            _persAssing = persAssing;
        }

        public void Add(RdCenterCalPersAssingDto rdCenterCalPersAssing)
        {
            _persAssing.Add(rdCenterCalPersAssing);
        }

        public void Update(RdCenterCalPersAssingDto rdCenterCalPersAssing)
        {
            _persAssing.Update(rdCenterCalPersAssing);
        }

        public void Delete(int id)
        {
            _persAssing.Delete(new RdCenterCalPersAssingDto { Id = id });
        }

        public RdCenterCalPersAssingDto GetById(int id)
        {
            return _persAssing.Get(x => x.Id == id);
        }

        public List<RdCenterCalPersAssingDto> GetAll()
        {
            return _persAssing.GetList();
        }
    }
}
