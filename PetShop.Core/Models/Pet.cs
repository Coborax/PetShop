using System;

namespace PetShop.Core.Models
{
    public class Pet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public PetType PetType { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        public Owner Owner { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}