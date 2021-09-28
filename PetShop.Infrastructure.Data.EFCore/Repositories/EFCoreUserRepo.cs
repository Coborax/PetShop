using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.Repositories;

namespace PetShop.Infrastructure.Data.EFCore.Repositories
{
    public class EFCoreUserRepo : EFCoreRepo<User>, IUserRepo
    {
        public EFCoreUserRepo(PetShopContext ctx) : base(ctx) { }
        
        public User Find(string username)
        {
            return _ctx.Set<User>().First(u => u.Username == username);
        }
    }
}