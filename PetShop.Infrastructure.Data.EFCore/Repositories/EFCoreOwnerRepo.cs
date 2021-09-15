using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.Repositories;
using PetShop.Infrastructure.Data.EFCore.Entities;

namespace PetShop.Infrastructure.Data.EFCore.Repositories
{
    public class EFCoreOwnerRepo : IOwnerRepo
    {
        private PetShopContext _ctx;

        public EFCoreOwnerRepo(PetShopContext ctx)
        {
            _ctx = ctx;
        }
        
        public Owner Find(int id)
        {
            OwnerEntity ownerEntity = _ctx.Owners.FirstOrDefault(entity => entity.ID == id);
            if (ownerEntity == null)
                return null;

            return EntityConverter.EntityToOwner(ownerEntity);
        }
    }
}