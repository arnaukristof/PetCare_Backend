using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetCare.Data;

namespace PetCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Worker_PetTypeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public Worker_PetTypeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllWorker_PetType()
        {
            return Ok(dbContext.Worker_PetTypes.ToList());
        }
    }
}
