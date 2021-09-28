using System;
using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Filtering;
using PetShop.Core.Models;
using PetShop.Core.Services;
using PetShop.Domain.Repositories;

namespace PetShop.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetTypeRepo _petTypeRepo;
        private readonly IUnitOfWork _unitOfWork;

        public PetService(IUnitOfWork unitOfWork, IPetTypeRepo petTypeRepo)
        {
            _unitOfWork = unitOfWork;
            _petTypeRepo = petTypeRepo;
        }

        public Pet Create(Pet pet)
        {
            PetType petType = _petTypeRepo.Find(pet.PetType.ID);
            if (petType == null)
                throw new Exception($"Pet typ with ID: {pet.PetType.ID}, does not exist");

            // Update pet type to use reference from repo
            pet.PetType = petType;

            pet = _unitOfWork.Pets.Create(pet);
            _unitOfWork.Complete();
            
            return pet;
        }

        public List<Pet> GetAll(Filter filter)
        {
            return _unitOfWork.Pets.Search(filter);
        }

        public Pet Find(int id)
        {
            return _unitOfWork.Pets.Find(id);
        }

        public List<Pet> Find(PetType petType)
        {
            return _unitOfWork.Pets.GetAll().Where(p => p.PetType.ID == petType.ID).ToList();
        }

        public Pet Update(Pet pet)
        {
            return _unitOfWork.Pets.Update(pet);
        }

        public bool Delete(int id)
        {
            Pet pet = _unitOfWork.Pets.Find(id);
            return pet != null && _unitOfWork.Pets.Delete(pet);
        }

        public List<Pet> GetCheapest(int n)
        {
            return _unitOfWork.Pets.GetCheapest(n);
        }
    }
}