using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.Models;
using PetShop.Infrastructure.Data.EFCore.Entities;

namespace PetShop.Infrastructure.Data.EFCore
{
    public class PetShopContext : DbContext
    {
        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<PetTypeEntity> PetTypes { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }
        public DbSet<User> Users { get; set; }

        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            List<PetEntity> pets = new List<PetEntity>();
            List<PetTypeEntity> petTypes = new List<PetTypeEntity>();
            
            petTypes.Add(new PetTypeEntity{ ID = 1, Name = "Bunny"});
            petTypes.Add(new PetTypeEntity{ ID = 2, Name = "Dog"});
            petTypes.Add(new PetTypeEntity{ ID = 3, Name = "Cat"});
            petTypes.Add(new PetTypeEntity{ ID = 4, Name = "Goat"});

            Faker<PetEntity> petFaker = new Faker<PetEntity>()
                .RuleFor(p => p.ID, (f, p) => f.IndexFaker + 1)
                .RuleFor(p => p.Name, (f, p) => f.Name.FirstName())
                .RuleFor(p => p.TypeID, (f, p) => f.PickRandom(petTypes).ID)
                .RuleFor(p => p.Birthdate, (f, p) => f.Date.Past())
                .RuleFor(p => p.SoldDate, (f, p) => f.Date.Past())
                .RuleFor(p => p.Color, (f, p) => f.Internet.Color())
                .RuleFor(p => p.Price, (f, p) => f.Commerce.Random.Double(10, 100000));

            
            pets.AddRange(petFaker.GenerateBetween(10, 20));
            
            modelBuilder.Entity<PetTypeEntity>().HasData(petTypes);
            modelBuilder.Entity<PetEntity>().HasData(pets);
            
        }
    }
}