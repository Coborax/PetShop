using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Domain.Repositories
{
    public interface IPetRepo : IRepo<Pet>
    {
        List<Pet> GetCheapest(int n);
    }
}