using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetCare.Data;
using PetCare.Models.Dtos;
using PetCare.Models.Entities;

namespace PetCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Worker_DaysOfWeekController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public Worker_DaysOfWeekController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllWorker_DaysOffWeek()
        {
            return Ok(dbContext.Worker_DaysOfWeeks.ToList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetWorker_DaysOffWeekById(int id)
        {
            var worker_DaysOfWeek = dbContext.Worker_DaysOfWeeks.Find(id);

            if (worker_DaysOfWeek == null)
            {
                return NotFound();
            }
            
            return Ok(worker_DaysOfWeek);
        }

        [HttpPost]
        public IActionResult AddWorker_DaysOffWeek(AddWorker_DaysOfWeekDto addWorker_DaysOfWeekDto)
        {
            var worker_DaysOfWeekEntity = new Worker_DaysOfWeek()
            {
                WorkerId = addWorker_DaysOfWeekDto.WorkerId,
                DaysOfWeekId = addWorker_DaysOfWeekDto.DaysOfWeekId
            };

            dbContext.Worker_DaysOfWeeks.Add(worker_DaysOfWeekEntity);
            dbContext.SaveChanges();

            return Ok(worker_DaysOfWeekEntity);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateWorker_DaysOffWeek(UpdateWorker_DaysOfWeekDto updateWorker_DaysOfWeekDto, int id)
        {
            var worker_DaysOfWeek = dbContext.Worker_DaysOfWeeks.Find(id);

            if (worker_DaysOfWeek == null)
            {
                return NotFound();
            }

            worker_DaysOfWeek.WorkerId = updateWorker_DaysOfWeekDto.WorkerId;
            worker_DaysOfWeek.DaysOfWeekId = updateWorker_DaysOfWeekDto.DaysOfWeekId;

            dbContext.SaveChanges();
            return Ok(worker_DaysOfWeek);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteWorker_DaysOffWeek(int id)
        {
            var worker_DaysOfWeek = dbContext.Worker_DaysOfWeeks.Find(id);

            if (worker_DaysOfWeek == null)
            {
                return NotFound();
            }

            dbContext.Worker_DaysOfWeeks.Remove(worker_DaysOfWeek);
            dbContext.SaveChanges();

            return Ok(worker_DaysOfWeek);
        }
    }
}
