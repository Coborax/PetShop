using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.Models;
using PetShop.Domain.Repositories;

namespace PetShop.Infrastructure.Data.EFCore.Repositories
{
    public class EFCoreUserRepo : EFCoreRepo<User>, IUserRepo
    {
        public EFCoreUserRepo(PetShopContext ctx) : base(ctx) { }
        
        public User Find(string username)
        {
            return _ctx.Set<User>()
                .Include(u => u.Roles)
                .First(u => u.Username == username);
        }
    }
}