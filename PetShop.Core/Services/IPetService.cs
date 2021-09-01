using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Core.Services
{
    public interface IPetService
    {
        Pet Create(Pet pet);
        List<Pet> GetAll();
        Pet Find(int id);
        Pet Update(Pet pet);
        bool Delete(int id);
        List<Pet> GetFiveCheapests();
    }
}