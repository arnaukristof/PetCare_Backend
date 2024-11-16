using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetCare.Data;
using PetCare.Models.Dtos;
using PetCare.Models.Entities;

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

        [HttpGet("GetAllWorker_PetTypes")]
        public IActionResult GetAllWorker_PetTypes()
        {
            return Ok(dbContext.Worker_PetTypes.ToList());
        }


        [HttpGet]
        [Route("GetWorker_PetTypeById{id:int}")]
        public IActionResult GetWorker_PetTypeById(int id)
        {
            var worker_PetType = dbContext.Worker_PetTypes.Find(id);

            if (worker_PetType == null)
            {
                return NotFound();
            }

            return Ok(worker_PetType);
        }

        [HttpPost("AddWorker_PetType")]
        public IActionResult AddWorker_PetType(AddWorker_PetTypeDto addWorker_PetTypeDto)
        {
            var worker_PetTypeEntity = new Worker_PetType()
            {
                WorkerId = addWorker_PetTypeDto.WorkerId,
                PetTypeId = addWorker_PetTypeDto.PetTypeId
            };

            dbContext.Worker_PetTypes.Add(worker_PetTypeEntity);
            dbContext.SaveChanges();

            return Ok(worker_PetTypeEntity);
        }

        [HttpPut]
        [Route("UpdateWorker_PetType{id:int}")]
        public IActionResult UpdateWorker_PetType(UpdateWorker_PetTypeDto updateWorker_PetTypeDto , int id)
        {
            var worker_PetType = dbContext.Worker_PetTypes.Find(id);

            if (worker_PetType == null)
            {
                return NotFound();
            }

            worker_PetType.WorkerId = updateWorker_PetTypeDto.WorkerId;
            worker_PetType.PetTypeId = updateWorker_PetTypeDto.PetTypeId;

            dbContext.SaveChanges();
            return Ok(worker_PetType);
        }

        [HttpDelete]
        [Route("DeleteWorker_PetType{id:int}")]
        public IActionResult DeleteWorker_PetType(int id)
        {
            var worker_PetType = dbContext.Worker_PetTypes.Find(id);

            if (worker_PetType == null)
            {
                return NotFound();
            }

            dbContext.Worker_PetTypes.Remove(worker_PetType);
            dbContext.SaveChanges();

            return Ok(worker_PetType);
        }
    }
}
