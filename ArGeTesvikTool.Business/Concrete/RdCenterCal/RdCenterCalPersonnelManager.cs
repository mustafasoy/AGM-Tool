using ArGeTesvikTool.Business.Abstract.RdCenterCal;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenterCal
{
    public class RdCenterCalPersonnelManager : IRdCenterCalPersonnelService
    {
        private readonly IRdCenterCalPersonnelDal _personnel;

        public RdCenterCalPersonnelManager(IRdCenterCalPersonnelDal personnel)
        {
            _personnel = personnel;
        }

        public void Add(RdCenterCalPersonnelInfoDto rdCenterCalPersonnel)
        {
            _personnel.Add(rdCenterCalPersonnel);
        }

        public void Update(RdCenterCalPersonnelInfoDto rdCenterCalPersonnel)
        {
            _personnel.Update(rdCenterCalPersonnel);
        }

        public void Delete(int id)
        {
            _personnel.Delete(new RdCenterCalPersonnelInfoDto { Id = id });
        }

        public RdCenterCalPersonnelInfoDto GetById(int id)
        {
            return _personnel.Get(x => x.Id == id);
        }

        public List<RdCenterCalPersonnelInfoDto> GetAll()
        {
            return _personnel.GetList();
        }
    }
}
