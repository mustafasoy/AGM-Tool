using ArGeTesvikTool.Entities.Concrete.Business;

namespace ArGeTesvikTool.Business.Abstract.Business
{
    public interface IBusinessIntroService
    {
        void Add(BusinessIntroDto businessInfo);
        void Update(BusinessIntroDto businessInfo);
        BusinessIntroDto GetByYear(int year);
    }
}
