using ArGeTesvikTool.Business.Abstract.RdCenterTech;
using ArGeTesvikTool.DataAccess.Abstract.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Concrete.RdCenterTech
{
    public class RdCenterTechMentorInfoManager : IRdCenterTechMentorInfoService
    {
        private readonly IRdCenterTechMentorInfoDal _rdCenterTechMentorInfo;

        public RdCenterTechMentorInfoManager(IRdCenterTechMentorInfoDal rdCenterTechMentorInfo)
        {
            _rdCenterTechMentorInfo = rdCenterTechMentorInfo;
        }

        public void Add(RdCenterTechMentorInfoDto rdCenterTechMentor)
        {
            _rdCenterTechMentorInfo.Add(rdCenterTechMentor);
        }

        public void Update(RdCenterTechMentorInfoDto rdCenterTechMentor)
        {
            _rdCenterTechMentorInfo.Update(rdCenterTechMentor);
        }

        public void Delete(int id)
        {
            _rdCenterTechMentorInfo.Delete(new RdCenterTechMentorInfoDto { Id = id });
        }

        public RdCenterTechMentorInfoDto GetById(int id)
        {
            return _rdCenterTechMentorInfo.Get(x => x.Id == id);
        }

        public List<RdCenterTechMentorInfoDto> GetAll()
        {
            return _rdCenterTechMentorInfo.GetList();
        }
    }
}
