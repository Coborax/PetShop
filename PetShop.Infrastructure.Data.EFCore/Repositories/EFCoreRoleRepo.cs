using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.Repositories;

namespace PetShop.Infrastructure.Data.EFCore.Repositories
{
    public class EFCoreRoleRepo: EFCoreRepo<Role>, IRoleRepo
    {
        public EFCoreRoleRepo(PetShopContext ctx) : base(ctx) { }

        public Role Find(string roleName)
        {
            return _ctx.Roles.FirstOrDefault(r => r.RoleName == roleName);
        }
    }
}