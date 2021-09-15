using System;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Models;
using PetShop.Core.Services;

namespace PetShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetTypeController : ControllerBase
    {
        private IPetTypeService _petTypeService;

        public PetTypeController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }

        [HttpGet("{id}")]
        public ActionResult<PetTypeDto> GetByID(int id)
        {
            try
            {
                PetType petType = _petTypeService.Find(id);

                if (petType == null)
                    return NotFound();

                return Ok(new PetTypeDto
                {
                    ID = petType.ID,
                    Name = petType.Name
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, "Server error");
            }
        }

        [HttpPost]
        public ActionResult<PetTypeDto> Post(PetTypePostDto petType)
        {
            try
            {
                PetType createdPetType = _petTypeService.Create(new PetType
                {
                    Name = petType.Name
                });

                return Ok(new PetTypeDto
                {
                    ID = createdPetType.ID,
                    Name = createdPetType.Name
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, "Server error");
            }
        }
    }
}