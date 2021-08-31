using System;
using System.Collections.Generic;
using PetShop.Domain.Repositories;

namespace PetShop.Infrastructure.Data.InMemory.Repositories
{
    public class InMemoryRepo<TEntity> : IRepo<TEntity>
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

        public TEntity Get(int id)
        {
            throw new NotImplementedException();
            //return _entities.Find();
        }
    }
}