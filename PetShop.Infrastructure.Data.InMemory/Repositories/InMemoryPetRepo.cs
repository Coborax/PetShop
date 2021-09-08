using System;
using System.Collections.Generic;
using PetShop.Core.Models;
using PetShop.Domain.Repositories;
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

            if (pet.Name != null)
                petToUpdate.Name = pet.Name;
            
            if (pet.Type != null)
                petToUpdate.Type = pet.Type;
            
            //TODO: Look for another solution
            if (pet.Birthdate != DateTime.MinValue)
                petToUpdate.Birthdate = pet.Birthdate;
           
            //TODO: Look for another solution
            if (pet.SoldDate != DateTime.MinValue)
                petToUpdate.SoldDate = pet.SoldDate;
            
            if (pet.Color != null)
                petToUpdate.Color = pet.Color;
            
            if (pet.Price > 0)
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