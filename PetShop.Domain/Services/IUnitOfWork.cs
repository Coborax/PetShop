using PetShop.Core.Models;
using PetShop.Domain.Repositories;

namespace PetShop.Domain.Services
{
    public interface IUnitOfWork
    {
        public IPetRepo PetRepo { get; }
        public IRepo<PetType> PetTypeRepo { get; }

        void Complete();
    }
}