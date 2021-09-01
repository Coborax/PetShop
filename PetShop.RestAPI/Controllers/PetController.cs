using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Models;
using PetShop.Core.Services;
using PetShop.Domain.Services;

namespace PetShop.RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : Controller
    {
        private IPetService _petService;
        
        public PetController(IPetService petService)
        {
            _petService = petService;
        }
        
        // GET All
        [HttpGet]
        public ActionResult<List<Pet>> Get()
        {
            return Ok(_petService.GetAll());
        }
        
        // GET by ID
        [HttpGet("{id}")]
        public ActionResult<List<Pet>> Get(int id)
        {
            return Ok(_petService.Find(id));
        }
        
        // GET Cheapest
        [HttpGet("Cheapest")]
        public ActionResult<List<Pet>> GetFiveCheapest()
        {
            return _petService.GetFiveCheapests();
        }
        
        [HttpPost]
        public ActionResult<Pet> Post(Pet pet)
        {
            Pet updatedPet = _petService.Create(pet);
            if (updatedPet != null)
                return Ok(updatedPet);

            return BadRequest();
        }
        
        [HttpPut]
        public ActionResult<Pet> Put(Pet pet)
        {
            Pet updatedPet = _petService.Update(pet);
            if (updatedPet != null)
                return Ok(updatedPet);

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_petService.Delete(id))
                return Ok();

            return BadRequest();
        }
    }
}