using System.Collections.Generic;

namespace PetShop.Core.Services
{
    public interface IService<T>
    {
        List<T> GetAll();
    }
}