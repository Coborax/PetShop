using Microsoft.EntityFrameworkCore;
using PetShop.Core.Services;
using PetShop.Domain.Repositories;

namespace PetShop.Infrastructure.Data.EFCore
{
    public class EFCoreUnitOfWork : IUnitOfWork
    {
        public IPetRepo Pets { get; }
        public IPetTypeRepo PetTypes { get; }
        public IOwnerRepo Owners { get; }
        public IUserRepo Users { get; }

        private readonly DbContext _ctx;
        
        public EFCoreUnitOfWork(PetShopContext ctx, IPetRepo pets, IPetTypeRepo petTypes, IOwnerRepo owners, IUserRepo users)
        {
            _ctx = ctx;
            Pets = pets;
            PetTypes = petTypes;
            Owners = owners;
            Users = users;
        }

        public void Complete()
        {
            _ctx.SaveChanges();
        }
    }
}