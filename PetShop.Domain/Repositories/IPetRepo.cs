using System.Collections.Generic;
using PetShop.Core.Filtering;
using PetShop.Core.Models;

namespace PetShop.Domain.Repositories
{
    public interface IPetRepo
    {
        Pet Create(Pet pet);
        List<Pet> GetAll(Filter filter = null);
        Pet Find(int id);
        Pet Update(Pet pet);
        bool Delete(Pet pet);
    }
}