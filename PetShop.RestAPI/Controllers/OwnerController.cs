using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Models;
using PetShop.Core.Services;

namespace PetShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet("{id}")]
        public ActionResult<Owner> GetByID(int id)
        {
            Owner owner = _ownerService.Find(id);

            if (owner == null)
                return NotFound();

            return Ok(owner);
        }
    }
}