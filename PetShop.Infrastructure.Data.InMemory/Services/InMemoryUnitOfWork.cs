using System;
using PetShop.Core.Models;
using PetShop.Domain.Repositories;
using PetShop.Domain.Services;

namespace PetShop.Infrastructure.Data.InMemory.Services
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        public IPetRepo PetRepo { get; }
        public IRepo<PetType> PetTypeRepo { get; }

        public InMemoryUnitOfWork(IPetRepo petRepo, IRepo<PetType> petTypeRepo)
        {
            PetRepo = petRepo;
            PetTypeRepo = petTypeRepo;
        }

        public void Complete()
        {
            Console.WriteLine("No need to write changes to local in memory DB");
        }
    }
}