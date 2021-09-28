using System.Linq;
using PetShop.Core.Models;

namespace PetShop.Infrastructure.Data.EFCore.Entities
{
    public static class EntityConverter
    {
        public static PetEntity PetToEntity(Pet pet)
        {
            return new PetEntity
            {
                ID = pet.Id,
                Name = pet.Name,
                TypeID = pet.PetType.Id,
                Birthdate = pet.Birthdate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price,
                OwnerID = pet.Owner.Id
            };
        }
        
        public static Pet EntityToPet(PetEntity pet)
        {
            return new Pet
            {
                Id = pet.ID,
                Name = pet.Name,
                PetType = new PetType {Id = pet.TypeID},
                Birthdate = pet.Birthdate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price,
                Owner = new Owner {Id = pet.OwnerID}
            };
        }
        
        public static PetTypeEntity PetTypeToEntity(PetType petType)
        {
            return new PetTypeEntity
            {
                ID = petType.Id,
                Name = petType.Name
            };
        }
        
        public static PetType EntityToPetType(PetTypeEntity petType)
        {
            return new PetType
            {
                Id = petType.ID,
                Name = petType.Name
            };
        }

        public static OwnerEntity OwnerToEntity(Owner owner)
        {
            return new OwnerEntity
            {
                ID = owner.Id,
                Name = owner.Name
            };
        }

        public static Owner EntityToOwner(OwnerEntity ownerEntity)
        {
            return new Owner
            {
                Id = ownerEntity.ID,
                Name = ownerEntity.Name
            };
        }
    }
}