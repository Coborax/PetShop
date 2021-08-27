using System.Collections.Generic;
using PetShop.Core.Models;
using PetShop.Domain.Repositories;

namespace PetShop.Infrastructure.Data.InMemory.Repositories
{
    public class InMemoryPetRepo : InMemoryRepo<Pet>
    {
        public InMemoryPetRepo(FakeDB db) : base(db.Pets) { }
    }
}