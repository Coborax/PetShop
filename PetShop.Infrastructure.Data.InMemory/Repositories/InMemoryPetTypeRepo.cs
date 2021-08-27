using System.Collections.Generic;
using PetShop.Core.Models;
using PetShop.Domain.Repositories;

namespace PetShop.Infrastructure.Data.InMemory.Repositories
{
    public class InMemoryPetTypeRepo : InMemoryRepo<PetType>
    {
        public InMemoryPetTypeRepo(FakeDB db) : base(db.PetTypes) { }
    }
}