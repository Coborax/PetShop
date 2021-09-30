using PetShop.Core.Models;

namespace PetShop.Domain.Repositories
{
    public interface IRoleRepo : IRepo<Role>
    {
        Role Find(string roleName);
    }
}