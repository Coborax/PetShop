using PetShop.Core.Models;

namespace PetShop.Core.Services
{
    public interface IPetTypeService
    {
        PetType Find(int id);
    }
}