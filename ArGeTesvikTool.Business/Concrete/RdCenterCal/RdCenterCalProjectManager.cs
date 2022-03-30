using ArGeTesvikTool.Business.Abstract.RdCenterCal;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenterCal
{
    public class RdCenterCalProjectManager : IRdCenterCalProjectService
    {
        private readonly IRdCenterCalProjectDal _project;

        public RdCenterCalProjectManager(IRdCenterCalProjectDal project)
        {
            _project = project;
        }

        public void Add(RdCenterCalProjectInfoDto rdCenterCalProject)
        {
            _project.Add(rdCenterCalProject);
        }

        public void Update(RdCenterCalProjectInfoDto rdCenterCalProject)
        {
            _project.Update(rdCenterCalProject);
        }

        public void Delete(int id)
        {
            _project.Delete(new RdCenterCalProjectInfoDto { Id = id });
        }

        public RdCenterCalProjectInfoDto GetById(int id)
        {
            return _project.Get(x => x.Id == id);
        }

        public List<RdCenterCalProjectInfoDto> GetAll()
        {
            return _project.GetList();
        }
    }
}
