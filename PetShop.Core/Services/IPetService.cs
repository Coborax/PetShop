using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Core.Services
{
    public interface IPetService
    {
        List<Pet> GetAll();
        Pet Find(int id);
        List<Pet> GetFiveCheapests();
    }
}