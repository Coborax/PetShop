using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Filtering;
using PetShop.Core.Models;
using PetShop.Domain.Repositories;
using PetShop.Infrastructure.Data.EFCore.Entities;

namespace PetShop.Infrastructure.Data.EFCore.Repositories
{
    public class EFCorePetRepo : IPetRepo
    {
        private PetShopContext _ctx;

        public EFCorePetRepo(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        public Pet Create(Pet pet)
        {
            PetEntity pe = EntityConverter.PetToEntity(pet);
            PetEntity createdPet = _ctx.Pets.Add(pe).Entity;
            _ctx.SaveChanges();

            return EntityConverter.EntityToPet(createdPet);
        }

        public List<Pet> GetAll(Filter filter)
        {
            if (filter != null)
            {
                return _ctx.Pets
                    .Select(pe => EntityConverter.EntityToPet(pe))
                    .Skip(filter.Count * (filter.Page - 1))
                    .Take(filter.Count)
                    .ToList();
            }
            
            return _ctx.Pets
                .Select(pe => EntityConverter.EntityToPet(pe))
                .ToList();
        }

        public Pet Find(int id)
        {
            return _ctx.Pets
                .Select(pe => EntityConverter.EntityToPet(pe))
                .FirstOrDefault(p => p.ID == id);
        }

        public Pet Update(Pet pet)
        {
            PetEntity pe = EntityConverter.PetToEntity(pet);
            PetEntity updatedPet = _ctx.Pets.Update(pe).Entity;
            _ctx.SaveChanges();

            return EntityConverter.EntityToPet(updatedPet);
        }

        public bool Delete(Pet pet)
        {
            _ctx.Pets.Remove(EntityConverter.PetToEntity(pet));
            _ctx.SaveChanges();

            return true;
        }
    }
}