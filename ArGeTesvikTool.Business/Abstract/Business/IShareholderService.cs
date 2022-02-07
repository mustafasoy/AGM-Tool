using ArGeTesvikTool.Entities.Concrete.Business;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.Business
{
    public interface IShareholderService
    {
        void Add(ShareholdersDto shareholder);
        void Update(ShareholdersDto shareholder);
        void Delete(int id);
        ShareholdersDto GetById(int id);
        List<ShareholdersDto> GetAll();
    }
}
