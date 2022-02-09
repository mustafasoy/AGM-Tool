using ArGeTesvikTool.Entities.Concrete.RdCenter;

namespace ArGeTesvikTool.Business.Abstract.RdCenter
{
    public interface IRdCenterInfoService
    {
        void Add(RdCenterInfoDto rdCenterInfo);
        void Update(RdCenterInfoDto rdCenterInfo);
        void Delete(int id);
        RdCenterInfoDto GetByYear(int year);
    }
}
