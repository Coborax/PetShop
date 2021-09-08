using System;
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
        private IPetTypeRepo _petTypeRepo;

        public PetService(IPetRepo petRepo, IPetTypeRepo petTypeRepo)
        {
            _petRepo = petRepo;
            _petTypeRepo = petTypeRepo;
        }

        public Pet Create(Pet pet)
        {
            PetType petType = _petTypeRepo.Find(pet.Type.ID);
            if (petType == null)
                throw new Exception($"Pet typ with ID: {pet.Type.ID}, does not exist");

            // Update pet type to use reference from repo
            pet.Type = petType;
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

        public List<Pet> GetCheapests(int n)
        {
            return _petRepo.GetAll().OrderBy(p => p.Price).Take(n).ToList();
        }
    }
}