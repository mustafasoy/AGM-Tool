using ArGeTesvikTool.Business.Abstract.RdCenter;
using ArGeTesvikTool.DataAccess.Abstract.RdCenter;
using ArGeTesvikTool.Entities.Concrete.RdCenter;

namespace ArGeTesvikTool.Business.Concrete.RdCenter
{
    public class RdCenterContactManager : IRdCenterContactService
    {
        private readonly IRdCenterContactInfoDal _rdCenterContactDal;

        public RdCenterContactManager(IRdCenterContactInfoDal rdCenterContactDal)
        {
            _rdCenterContactDal = rdCenterContactDal;
        }
        public void Add(RdCenterContactDto rdCenterContact)
        {
            _rdCenterContactDal.Add(rdCenterContact);
        }

        public void Update(RdCenterContactDto rdCenterContact)
        {
            _rdCenterContactDal.Update(rdCenterContact);
        }

        public void Delete(int id)
        {
            _rdCenterContactDal.Delete(new RdCenterContactDto { Id = id });
        }

        public RdCenterContactDto GetByYear(int year)
        {
            return _rdCenterContactDal.Get(x => x.Year == year);
        }
    }
}
