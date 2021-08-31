using System.Collections.Generic;
using PetShop.Core.Services;
using PetShop.Domain.Repositories;

namespace PetShop.Domain.Services
{
    public class GenericService<T> : IService<T>
    {
        private IRepo<T> _repo;

        public GenericService(IRepo<T> repo)
        {
            _repo = repo;
        }

        public List<T> GetAll()
        {
            return _repo.GetAll();
        }
    }
}