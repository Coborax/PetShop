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
        private readonly IUnitOfWork _unitOfWork;

        public PetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Pet Create(Pet pet)
        { 
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