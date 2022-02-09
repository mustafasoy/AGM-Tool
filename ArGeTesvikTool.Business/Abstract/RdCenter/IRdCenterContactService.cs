using ArGeTesvikTool.Entities.Concrete.RdCenter;

namespace ArGeTesvikTool.Business.Abstract.RdCenter
{
    public interface IRdCenterContactService
    {
        void Add(RdCenterContactDto rdCenterContact);
        void Update(RdCenterContactDto rdCenterContact);
        void Delete(int id);
        RdCenterContactDto GetByYear(int year);
    }
}
