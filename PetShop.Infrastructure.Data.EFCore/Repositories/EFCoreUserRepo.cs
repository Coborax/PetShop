using System.Linq;
using PetShop.Core.Models;
using PetShop.Domain.Repositories;

namespace PetShop.Infrastructure.Data.EFCore.Repositories
{
    public class EFCoreUserRepo : IUserRepo
    {
        private PetShopContext _ctx;

        public EFCoreUserRepo(PetShopContext ctx)
        {
            _ctx = ctx;
        }
        
        public User Find(string username)
        {
            return _ctx.Users.FirstOrDefault(u => u.Username == username);
        }

        public User Add(User user)
        {
            _ctx.Users.Add(user);
            _ctx.SaveChanges();

            return _ctx.Users.Find(user.ID);
        }
    }
}