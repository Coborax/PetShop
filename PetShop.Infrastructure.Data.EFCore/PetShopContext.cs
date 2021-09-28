using System.Collections.Generic;
using System.Linq;
using Bogus;
using Bogus.Extensions;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.Models;
using PetShop.Infrastructure.Data.EFCore.Entities;

namespace PetShop.Infrastructure.Data.EFCore
{
    public class PetShopContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<User> Users { get; set; }

        public PetShopContext(DbContextOptions<PetShopContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            List<Pet> pets = new List<Pet>();
            List<PetType> petTypes = new List<PetType>
            {
                new() { ID = 1, Name = "Bunny" },
                new() { ID = 2, Name = "Dog" },
                new() { ID = 3, Name = "Cat"},
                new() { ID = 4, Name = "Goat"}
            };

            Faker<Pet> petFaker = new Faker<Pet>()
                .RuleFor(p => p.ID, (f, _) => f.IndexFaker + 1)
                .RuleFor(p => p.Name, (f, _) => f.Name.FirstName())
                 //.RuleFor(p => p.PetType, (f, _) => f.PickRandom(petTypes))
                .RuleFor(p => p.Birthdate, (f, _) => f.Date.Past())
                .RuleFor(p => p.SoldDate, (f, _) => f.Date.Past())
                .RuleFor(p => p.Color, (f, _) => f.Internet.Color())
                .RuleFor(p => p.Price, (f, _) => f.Commerce.Random.Double(100, 5000));

            
            pets.AddRange(petFaker.GenerateBetween(50, 100));
            
            //modelBuilder.Entity<PetType>().HasData(petTypes);
            //modelBuilder.Entity<Pet>().HasData(pets);
        }
    }
}