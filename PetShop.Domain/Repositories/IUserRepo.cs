using PetShop.Core.Models;

namespace PetShop.Domain.Repositories
{
    public interface IUserRepo
    {
        User Find(string username);
        User Add(User user);
    }
}