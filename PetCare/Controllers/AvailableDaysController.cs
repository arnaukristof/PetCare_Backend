using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetCare.Data;

namespace PetCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailableDaysController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public AvailableDaysController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAvailableDays(int petTypeId) 
        {
            var availableDays = dbContext.Worker_PetTypes
                .Where(wp => wp.PetTypeId == petTypeId)
                .SelectMany(wp => dbContext.Worker_DaysOfWeeks
                    .Where(wd => wd.WorkerId == wp.WorkerId)
                    .Select(wd => wd.DaysOfWeek.NameOfDay))
                .Distinct()
                .ToList();

            return Ok(availableDays);
        }
    }
}
