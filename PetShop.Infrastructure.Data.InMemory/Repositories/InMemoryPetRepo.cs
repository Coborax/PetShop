using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.Repositories;
using PetShop.Domain.Services;

namespace PetShop.Infrastructure.Data.InMemory.Repositories
{
    public class InMemoryPetRepo : IPetRepo
    {
        private List<Pet> _pets;

        public InMemoryPetRepo(FakeDB db)
        {
            _pets = db.Pets;
        }

        public List<Pet> GetAll()
        {
            return _pets;
        }

        public Pet Find(int id)
        {
            return _pets.Find(p => p.ID == id);
        }
    }
}