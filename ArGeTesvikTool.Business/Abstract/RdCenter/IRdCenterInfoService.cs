using ArGeTesvikTool.Entities.Concrete.RdCenter;

namespace ArGeTesvikTool.Business.Abstract.RdCenter
{
    public interface IRdCenterInfoService
    {
        void Add(RdCenterInfoDto rdCenterInfo);
        void Update(RdCenterInfoDto rdCenterInfo);
        RdCenterInfoDto GetByYear(int year);
    }
}
