using System.Collections.Generic;
using PetShop.Core.Filtering;
using PetShop.Core.Models;

namespace PetShop.Core.Services
{
    public interface IPetService
    {
        Pet Create(Pet pet);
        List<Pet> GetAll(Filter filter = null);
        Pet Find(int id);
        List<Pet> Find(PetType petType);
        Pet Update(Pet pet);
        bool Delete(int id);
        List<Pet> GetCheapest(int n);
    }
}