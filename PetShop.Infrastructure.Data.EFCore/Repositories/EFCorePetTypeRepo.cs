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
            return EntityConverter.EntityToPetType(_ctx.PetTypes.FirstOrDefault(pe => pe.ID == id));
        }

        public List<PetType> GetAll()
        {
            return _ctx.PetTypes.Select(pe => EntityConverter.EntityToPetType(pe)).ToList();
        }
    }
}