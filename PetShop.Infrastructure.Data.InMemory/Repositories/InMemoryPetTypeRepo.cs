using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.Repositories;

namespace PetShop.Infrastructure.Data.InMemory.Repositories
{
    public class InMemoryPetTypeRepo : IPetTypeRepo
    {
        private readonly List<PetType> _petTypes;

        public InMemoryPetTypeRepo(FakeDB db)
        {
            _petTypes = db.PetTypes;
        }
        
        public PetType Find(int id)
        {
            return _petTypes.FirstOrDefault(p => p.ID == id);
        }

        public List<PetType> GetAll()
        {
            return _petTypes;
        }

        public PetType Create(PetType petType)
        {
            petType.ID = _petTypes.Count + 1;
            _petTypes.Add(petType);

            return petType;
        }
    }
}