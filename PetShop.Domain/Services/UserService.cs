using PetShop.Core.Models;
using PetShop.Core.Services;
using PetShop.Domain.Repositories;

namespace PetShop.Domain.Services
{
    public class UserService : IUserService
    {
        private IUserRepo _repo;

        public UserService(IUserRepo repo)
        {
            _repo = repo;
        }

        public User Find(string username)
        {
            return _repo.Find(username);
        }

        public User Add(User user)
        {
            return _repo.Add(user);
        }
    }
}