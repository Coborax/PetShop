using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Filtering;
using PetShop.Core.Models;
using PetShop.Core.Services;
using PetShop.RestAPI.DTOs;

namespace PetShop.RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : Controller
    {
        private IPetService _petService;
        private IPetTypeService _petTypeService;
        
        public PetController(IPetService petService, IPetTypeService petTypeService)
        {
            _petService = petService;
            _petTypeService = petTypeService;
        }
        
        // GET All
        [HttpGet]
        public ActionResult<List<PetDto>> Get([FromQuery]Filter filter)
        {
            return Ok(_petService.GetAll(filter).Select(PetToDto));
        }
        
        // GET by ID
        [HttpGet("{id}")]
        public ActionResult<PetDto> Get(int id)
        {
            return Ok(PetToDto(_petService.Find(id)));
        }
        
        // GET Cheapest
        [HttpGet("Cheapest/{n}")]
        public ActionResult<List<PetDto>> GetFiveCheapest(int n)
        {
            return _petService.GetCheapest(n).Select(PetToDto).ToList();
        }
        
        // POST (Create)
        [HttpPost]
        public ActionResult<PetDto> Post(PostPetDto pet)
        {
            Pet fromDto = new Pet
            {
                Name = pet.Name,
                PetTypeId = pet.TypeID,
                Birthdate = pet.Birthdate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price
            };
            
            Pet createdPet = _petService.Create(fromDto);
            if (createdPet != null)
                return Ok(PetToDto(createdPet));

            return BadRequest();
        }
        
        // PUT (Update)
        [HttpPut]
        public ActionResult<Pet> Put(Pet pet)
        {
            Pet updatedPet = _petService.Update(pet);
            if (updatedPet != null)
                return Ok(updatedPet);

            return BadRequest();
        }

        // Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_petService.Delete(id))
                return Ok();

            return BadRequest();
        } 
        
        private PetDto PetToDto(Pet pet)
        {
            return new()
            {
                ID = pet.Id,
                Name = pet.Name,
                TypeID = pet.PetTypeId,
                Birthdate = pet.Birthdate,
                SoldDate = pet.SoldDate,
                Color = pet.Color,
                Price = pet.Price
            };
        }
    }
}