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

        public List<Pet> GetAll()
        {
            return _petRepo.GetAll();
        }

        public Pet Find(int id)
        {
            return _petRepo.Find(id);
        }

        public List<Pet> GetFiveCheapests()
        {
            return _petRepo.GetAll().OrderBy(p => p.Price).Take(5).ToList();
        }
    }
}