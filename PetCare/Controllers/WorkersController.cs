using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCare.Data;
using PetCare.Models.Dtos;
using PetCare.Models.Entities;

namespace PetCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public WorkersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllWorkers() 
        {
            return Ok(dbContext.Workers.ToList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetPetById(int id)
        {
            var worker = dbContext.Workers.Find(id);

            if (worker == null)
            {
                return NotFound();
            }
            return Ok(worker);
        }

        [HttpPost]
        public IActionResult AddWorker(AddWorkerDto addWorkerDto)
        {
            var workerEntity = new Worker()
            {
                Name = addWorkerDto.Name
            };

            dbContext.Workers.Add(workerEntity);
            dbContext.SaveChanges();

            return Ok(workerEntity);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateWorkers(int id, UpdateWorkerDto updateWorkerDto)
        {
            var worker = dbContext.Workers.Find(id);

            if (worker == null)
            { 
                return NotFound();
            }
            worker.Name = updateWorkerDto.Name;

            dbContext.SaveChanges();
            return Ok(worker);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteWorker(int id)
        {
            var worker = dbContext.Workers.Find(id);

            if (worker == null)
            {
                return NotFound();
            }

            dbContext.Workers.Remove(worker);
            dbContext.SaveChanges();

            return Ok(worker);
        }

        [HttpGet("GetWorkersWithAdditionalData")]
        public async Task<IActionResult> GetWorkersWithAdditionalData()
        {
            var workers = await dbContext.Workers
                .Select(w => new
                {
                    w.Id,
                    w.Name,
                    PetTypes = w.Worker_PetTypes.Select(wp => wp.PetType.TypeName).ToList(),
                    DaysOfWeek = w.Worker_DaysOfWeeks.Select(wd => wd.DaysOfWeek.NameOfDay).ToList()
                })
                .ToListAsync();

            return Ok(workers);
        }

        [HttpPost("CreateWorker")]
        public async Task<IActionResult> CreateWorker([FromBody] CreateWorkerDto createWorkerDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var worker = new Worker
            {
                Name = createWorkerDto.Name
            };

            dbContext.Workers.Add(worker);
            await dbContext.SaveChangesAsync();

            if (createWorkerDto.PetTypeIds != null)
            {
                foreach (var petTypeId in createWorkerDto.PetTypeIds)
                {
                    var workerPetType = new Worker_PetType
                    {
                        WorkerId = worker.Id,
                        PetTypeId = petTypeId
                    };
                    createWorkerDto.Worker_PetTypes.Add(workerPetType);
                }
            }

            if (createWorkerDto.DaysOfWeekIds != null)
            {
                foreach (var daysOfWeekId in createWorkerDto.DaysOfWeekIds)
                {
                    var workerDay = new Worker_DaysOfWeek
                    {
                        WorkerId = worker.Id,
                        DaysOfWeekId = daysOfWeekId
                    };
                    createWorkerDto.Worker_DaysOfWeeks.Add(workerDay);
                }
            }

            await dbContext.SaveChangesAsync();
            return Ok(worker);
        }
    }
}
