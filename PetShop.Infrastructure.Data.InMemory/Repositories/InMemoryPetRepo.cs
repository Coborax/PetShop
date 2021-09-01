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

        public Pet Create(Pet pet)
        {
            _pets.Add(pet);
            pet.ID = _pets.Count + 1;
            return pet;
        }

        public List<Pet> GetAll()
        {
            return _pets;
        }

        public Pet Find(int id)
        {
            return _pets.Find(p => p.ID == id);
        }

        public Pet Update(Pet pet)
        {
            Pet petToUpdate = Find(pet.ID);
            if (petToUpdate == null)
                return null;

            petToUpdate.Name = pet.Name;
            petToUpdate.Type = pet.Type;
            petToUpdate.Birthdate = pet.Birthdate;
            petToUpdate.SoldDate = pet.SoldDate;
            petToUpdate.Color = pet.Color;
            petToUpdate.Price = pet.Price;
            
            return petToUpdate;
        }

        public bool Delete(Pet pet)
        {
            if (_pets.Contains(pet))
            {
                _pets.Remove(pet);
                return true;
            }

            return false;
        }
    }
}