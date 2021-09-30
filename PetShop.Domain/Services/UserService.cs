using PetShop.Core.Models;
using PetShop.Core.Services;

namespace PetShop.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User Find(string username)
        {
            return _unitOfWork.Users.Find(username);
        }

        public User Add(User user)
        {
            user = _unitOfWork.Users.Create(user);
            _unitOfWork.Complete();
            return user;
        }

        public Role FindRole(string roleName)
        {
            return _unitOfWork.Roles.Find(roleName);
        }
    }
}