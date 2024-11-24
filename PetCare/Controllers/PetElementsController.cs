using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetCare.Data;

namespace PetCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetElementsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public PetElementsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("GetPetSizes")]
        public IActionResult GetPetSizes() { 
            return Ok(dbContext.PetSizes.ToList());
        }

        [HttpGet("GetPetTypes")]
        public IActionResult GetPetTypes()
        {
            return Ok(dbContext.PetTypes.ToList());
        }

        [HttpGet("GetPetBreeds")]
        public IActionResult GetPetBreeds()
        {
            return Ok(dbContext.PetBreeds.ToList());
        }
    }
}
