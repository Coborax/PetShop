using System;

namespace PetShop.Infrastructure.Data.EFCore.Entities
{
    public class PetEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int TypeID { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
    }
}