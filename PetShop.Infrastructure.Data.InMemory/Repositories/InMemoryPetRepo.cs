using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.Repositories;

namespace PetShop.Infrastructure.Data.InMemory.Repositories
{
    public class InMemoryPetRepo : InMemoryRepo<Pet>, IPetRepo
    {
        public InMemoryPetRepo(FakeDB db) : base(db.Pets) { }
        public List<Pet> GetFiveCheapest()
        {
            return GetAll().OrderBy(p => p.Price).Take(5).ToList();
        }
    }
}