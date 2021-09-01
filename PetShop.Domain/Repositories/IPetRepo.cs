﻿using System.Collections.Generic;
using PetShop.Core.Models;

namespace PetShop.Domain.Repositories
{
    public interface IPetRepo
    {
        List<Pet> GetAll();
        Pet Find(int id);
    }
}