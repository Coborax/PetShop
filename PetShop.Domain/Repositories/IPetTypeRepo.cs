using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Domain.Repositories
{
    public interface IPetTypeRepo
    {
        PetType Find(int id);
        List<PetType> GetAll();
        PetType Create(PetType petType);
    }
}