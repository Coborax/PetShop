using PetShop.Core.Models;

namespace PetShop.Core.Services
{
    public interface IUserService
    {
        User Find(string username);
        User Add(User user);
    }
}