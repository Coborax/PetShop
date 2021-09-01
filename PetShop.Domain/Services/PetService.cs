using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Models;
using PetShop.Core.Services;
using PetShop.Domain.Repositories;

namespace PetShop.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepo _petRepo;

        public PetService(IPetRepo petRepo)
        {
            _petRepo = petRepo;
        }

        public Pet Create(Pet pet)
        {
            return _petRepo.Create(pet);
        }

        public List<Pet> GetAll()
        {
            return _petRepo.GetAll();
        }

        public Pet Find(int id)
        {
            return _petRepo.Find(id);
        }

        public Pet Update(Pet pet)
        {
            return _petRepo.Update(pet);
        }

        public bool Delete(int id)
        {
            Pet pet = _petRepo.Find(id);
            return pet != null && _petRepo.Delete(pet);
        }

        public List<Pet> GetFiveCheapests()
        {
            return _petRepo.GetAll().OrderBy(p => p.Price).Take(5).ToList();
        }
    }
}