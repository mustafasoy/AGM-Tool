using ArGeTesvikTool.Entities.Concrete.Index;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract.Index
{
    public interface INewDataService
    {
        void Add(NewDataDto newData);
        void Update(NewDataDto newData);
        void Delete(int id);
        NewDataDto GetByYear(int year);
    }
}
