using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.Repositories;

namespace PetShop.Infrastructure.Data.EFCore.Repositories
{
    public class EFCorePetRepo : EFCoreRepo<Pet>, IPetRepo
    {
        public EFCorePetRepo(PetShopContext ctx) : base(ctx) { }
        public List<Pet> GetCheapest(int n)
        {
            return _ctx.Set<Pet>().OrderBy(p => p.Price).Take(n).ToList();
        }
    }
}