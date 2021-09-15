using PetShop.Core.Models;

namespace PetShop.Core.Services
{
    public interface IOwnerService
    {
        Owner Find(int id);
    }
}