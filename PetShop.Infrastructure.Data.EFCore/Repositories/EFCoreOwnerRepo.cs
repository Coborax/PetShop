using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.Repositories;
using PetShop.Infrastructure.Data.EFCore.Entities;

namespace PetShop.Infrastructure.Data.EFCore.Repositories
{
    public class EFCoreOwnerRepo : EFCoreRepo<Owner>, IOwnerRepo
    {
        public EFCoreOwnerRepo(PetShopContext ctx) : base(ctx) { }
    }
}