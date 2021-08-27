using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;
using PetShop.Core.Models;

namespace PetShop.Infrastructure.Data.InMemory
{
    public class FakeDB
    {
        public List<Pet> Pets { get; private set; }
        public List<PetType> PetTypes { get; private set; }

        public FakeDB()
        {
            Pets = new List<Pet>();
            PetTypes = new List<PetType>();
            
            PetTypes.Add(new PetType{ ID = 1, Name = "Bunny"});
            PetTypes.Add(new PetType{ ID = 2, Name = "Dog"});
            PetTypes.Add(new PetType{ ID = 3, Name = "Cat"});
            PetTypes.Add(new PetType{ ID = 4, Name = "Goat"});

            Faker<Pet> petFaker = new Faker<Pet>()
                .RuleFor(p => p.ID, (f, p) => f.IndexFaker)
                .RuleFor(p => p.Name, (f, p) => f.Name.FirstName())
                .RuleFor(p => p.Type, (f, p) => f.PickRandom(PetTypes))
                .RuleFor(p => p.Birthdate, (f, p) => f.Date.Past())
                .RuleFor(p => p.SoldDate, (f, p) => f.Date.Past())
                .RuleFor(p => p.Color, (f, p) => f.Internet.Color())
                .RuleFor(p => p.Price, (f, p) => f.Commerce.Random.Double(10, 100000));

            
            Pets.AddRange(petFaker.GenerateBetween(10, 100));
        }
    }
}