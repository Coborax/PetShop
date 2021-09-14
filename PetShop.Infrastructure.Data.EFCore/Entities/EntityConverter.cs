using PetShop.Core.Models;

namespace PetShop.Infrastructure.Data.EFCore.Entities
{
    public static class EntityConverter
    {
        public static PetEntity PetToEntity(Pet pet)
        {
            return new PetEntity
            {
                ID = pet.ID,
                Name = pet.Name,
                TypeID = pet.Type.ID,
                Birthdate = pet.Birthdate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price
            };
        }
        
        public static Pet EntityToPet(PetEntity pet)
        {
            return new Pet
            {
                ID = pet.ID,
                Name = pet.Name,
                Type = new PetType {ID = pet.TypeID},
                Birthdate = pet.Birthdate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price
            };
        }
        
        public static PetTypeEntity PetTypeToEntity(PetType petType)
        {
            return new PetTypeEntity
            {
                ID = petType.ID,
                Name = petType.Name
            };
        }
        
        public static PetType EntityToPetType(PetTypeEntity petType)
        {
            return new PetType
            {
                ID = petType.ID,
                Name = petType.Name
            };
        }
    }
}