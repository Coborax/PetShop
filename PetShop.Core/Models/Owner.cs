using System.Collections.Generic;

namespace PetShop.Core.Models
{
    public class Owner
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Pet> Pets { get; set; }
    }
}