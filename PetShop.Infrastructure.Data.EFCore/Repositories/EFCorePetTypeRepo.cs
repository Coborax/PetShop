using PetShop.Core.Models;
using PetShop.Domain.Repositories;

namespace PetShop.Infrastructure.Data.EFCore.Repositories
{
    public class EFCorePetTypeRepo : EFCoreRepo<PetType>, IPetTypeRepo
    {
        public EFCorePetTypeRepo(PetShopContext ctx) : base(ctx) { }
    }
}