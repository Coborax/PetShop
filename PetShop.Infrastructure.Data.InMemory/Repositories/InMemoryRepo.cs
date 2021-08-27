using System.Collections.Generic;
using PetShop.Domain.Repositories;

namespace PetShop.Infrastructure.Data.InMemory.Repositories
{
    public class InMemoryRepo<T> : IRepo<T>
    {
        private List<T> _entities;

        public InMemoryRepo(List<T> entities)
        {
            _entities = entities;
        }

        public List<T> GetAll()
        {
            return _entities;
        }
    }
}