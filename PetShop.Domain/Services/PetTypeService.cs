﻿using System.Collections.Generic;
using PetShop.Core.Models;
using PetShop.Core.Services;
using PetShop.Domain.Repositories;

namespace PetShop.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {
        private IPetTypeRepo _repo;

        public PetTypeService(IPetTypeRepo repo)
        {
            _repo = repo;
        }

        public PetType Find(int id)
        {
            return _repo.Find(id);
        }

        public List<PetType> GetAll()
        {
            return _repo.GetAll();
        }

        public PetType Create(PetType petType)
        {
            return _repo.Create(petType);
        }
    }
}