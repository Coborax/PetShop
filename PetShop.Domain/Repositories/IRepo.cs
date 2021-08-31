using System.Collections.Generic;

namespace PetShop.Domain.Repositories
{
    public interface IRepo<T>
    {
        List<T> GetAll();
        T Find(int id);

    }
}