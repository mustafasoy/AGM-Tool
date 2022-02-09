using ArGeTesvikTool.Business.Abstract.RdCenterTech;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenterTech
{
    public class RdCenterTechCollaborationManager : IRdCenterTechCollaborationService
    {
        private readonly IRdCenterTechCollaborationDal _collabortionDal;

        public RdCenterTechCollaborationManager(IRdCenterTechCollaborationDal collaborationDal)
        {
            _collabortionDal = collaborationDal;
        }

        public void Add(RdCenterTechCollaborationDto rdCenterTechCollaboration)
        {
            _collabortionDal.Add(rdCenterTechCollaboration);
        }

        public void Update(RdCenterTechCollaborationDto rdCenterTechCollaboration)
        {
            _collabortionDal.Update(rdCenterTechCollaboration);
        }

        public void Delete(int id)
        {
            _collabortionDal.Delete(new RdCenterTechCollaborationDto { Id = id });
        }

        public RdCenterTechCollaborationDto GetById(int id)
        {
            return _collabortionDal.Get(x => x.Id == id);
        }

        public List<RdCenterTechCollaborationDto> GetAll()
        {
            return _collabortionDal.GetList();
        }
    }
}
