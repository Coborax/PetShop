using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.Repositories;
using PetShop.Infrastructure.Data.EFCore.Entities;

namespace PetShop.Infrastructure.Data.EFCore.Repositories
{
    public class EFCorePetTypeRepo : IPetTypeRepo
    {
        private PetShopContext _ctx;

        public EFCorePetTypeRepo(PetShopContext ctx)
        {
            _ctx = ctx;
        }
        public PetType Find(int id)
        {
            PetTypeEntity pe = _ctx.PetTypes.FirstOrDefault(pe => pe.ID == id);
            if (pe == null)
                return null;
            return EntityConverter.EntityToPetType(pe);
        }

        public List<PetType> GetAll()
        {
            return _ctx.PetTypes.Select(pe => EntityConverter.EntityToPetType(pe)).ToList();
        }

        public PetType Create(PetType petType)
        {
            PetTypeEntity pte = EntityConverter.PetTypeToEntity(petType);
            PetTypeEntity createdPte = _ctx.PetTypes.Add(pte).Entity;
            _ctx.SaveChanges();

            return EntityConverter.EntityToPetType(createdPte);
        }
    }
}