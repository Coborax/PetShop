using System;

namespace PetShop.RestAPI.DTOs
{
    public class PostPetDto
    {
        public string Name { get; set; }
        public int TypeID { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
    }
}