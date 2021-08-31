﻿using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Domain.Repositories
{
    public interface IRepo<TEntity>
    {
        List<TEntity> GetAll();
        TEntity Get(int id);
    }
}