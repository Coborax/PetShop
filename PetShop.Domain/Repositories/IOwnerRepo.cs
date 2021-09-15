using PetShop.Core.Models;

namespace PetShop.Domain.Repositories
{
    public interface IOwnerRepo
    {
        Owner Find(int id);
    }
}