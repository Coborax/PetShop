using PetShop.Core.Models;
using PetShop.Core.Services;
using PetShop.Domain.Repositories;

namespace PetShop.Domain.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepo _repo;

        public OwnerService(IOwnerRepo repo)
        {
            _repo = repo;
        }

        public Owner Find(int id)
        {
            return _repo.Find(id);
        }
    }
}