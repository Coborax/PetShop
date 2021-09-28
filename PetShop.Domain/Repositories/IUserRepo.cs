using PetShop.Core.Models;

namespace PetShop.Domain.Repositories
{
    public interface IUserRepo : IRepo<User>
    {
        User Find(string username);
    }
}