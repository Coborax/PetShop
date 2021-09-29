using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Filtering;
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

        public new List<Pet> Search(Filter filter)
        {
            List<Pet> result = base.Search(filter);

            if (string.IsNullOrEmpty(filter.SortType) || filter.SortType.Equals("asc"))
                result = result
                    .OrderBy(p => p.Name)
                    .Where(p => p.Name.ToLower().Contains(filter.SearchTerm.ToLower()))
                    .ToList();
            else if (filter.SortType.Equals("desc"))
                result = result
                    .OrderByDescending(p => p.Name)
                    .Where(p => p.Name.ToLower().Contains(filter.SearchTerm.ToLower()))
                    .ToList();

            return result;
        }
    }
}