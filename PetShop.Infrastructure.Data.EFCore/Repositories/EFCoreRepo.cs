using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.Filtering;
using PetShop.Domain.Repositories;

namespace PetShop.Infrastructure.Data.EFCore.Repositories
{
    public class EFCoreRepo<T> : IRepo<T> where T : class
    {
        protected DbContext _ctx;

        public EFCoreRepo(DbContext ctx)
        {
            _ctx = ctx;
        }

        public T Create(T toCreate)
        {
            return _ctx.Set<T>().Add(toCreate).Entity;
        }

        public List<T> GetAll()
        {
            return _ctx.Set<T>().ToList();
        }

        public List<T> Search(Filter filter)
        {
            return _ctx.Set<T>()
                .Skip(filter.Count * (filter.Page - 1))
                .Take(filter.Count)
                .ToList();
        }

        public T Find(int id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public T Update(T toUpdate)
        {
            return _ctx.Set<T>().Update(toUpdate).Entity;
        }

        public bool Delete(T toDelete)
        {
            try
            {
                _ctx.Set<T>().Remove(toDelete);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}