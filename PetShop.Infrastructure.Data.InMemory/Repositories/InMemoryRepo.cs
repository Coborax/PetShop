using System.Collections.Generic;
using PetShop.Core.Models;
using PetShop.Domain.Repositories;

namespace PetShop.Infrastructure.Data.InMemory.Repositories
{
    public class InMemoryRepo<T> : IRepo<T> where T : Entity
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

        public T Find(int id)
        {
            return _entities.Find(e => e.ID == id);
        }
    }
}