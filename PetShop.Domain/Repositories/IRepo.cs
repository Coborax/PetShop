using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Domain.Repositories
{
    public interface IRepo<T>
    {
        List<T> GetAll();
        T Find(int id);

    }
}