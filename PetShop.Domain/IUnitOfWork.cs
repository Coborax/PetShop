using PetShop.Core.Models;
using PetShop.Domain.Repositories;

namespace PetShop.Domain
{
    public interface IUnitOfWork
    {
        IPetRepo Pets { get; }
        IPetTypeRepo PetTypes { get; }
        IOwnerRepo Owners { get; }
        IUserRepo Users { get; }
        IRoleRepo Roles { get; }
        void Complete();
    }
}