using System.Collections.Generic;
using PetShop.Core.Filtering;

namespace PetShop.Domain.Repositories
{
    public interface IRepo<T>
    {
        T Create(T toCreate);
        List<T> GetAll();
        List<T> Search(Filter filter);
        T Find(int id);
        T Update(T toUpdate);
        bool Delete(T toDelete);
    }
}