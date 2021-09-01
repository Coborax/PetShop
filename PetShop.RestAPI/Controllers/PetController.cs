using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Models;
using PetShop.Domain.Services;

namespace PetShop.RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : Controller
    {
        private IUnitOfWork _unitOfWork;
        
        public PetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        // GET All
        [HttpGet]
        public ActionResult<List<Pet>> Get()
        {
            return Ok(_unitOfWork.PetRepo.GetAll());
        }
        
        // GET by ID
        [HttpGet("{id}")]
        public ActionResult<List<Pet>> Get(int id)
        {
            return Ok(_unitOfWork.PetRepo);
        }
        
        // GET Cheapest
        [HttpGet("Cheapest")]
        public ActionResult<List<Pet>> GetFiveCheapest()
        {
            return Ok(_unitOfWork.PetRepo.GetFiveCheapests());
        }
        
        
    }
}