using System.Collections.Generic;
using PetShop.Core.Models;
using PetShop.Domain.Repositories;

namespace PetShop.Infrastructure.Data.InMemory.Repositories
{
    public class InMemoryRepo<T> : IRepo<T> where T : Entity
    {
        private List<TEntity> _entities;

        public InMemoryRepo(List<TEntity> entities)
        {
            _entities = entities;
        }

        public List<TEntity> GetAll()
        {
            return _entities;
        }

        public T Find(int id)
        {
            return _entities.Find(e => e.ID == id);
        }
    }
}