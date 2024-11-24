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
    public class ScheduleController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ScheduleController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("GetAllSchedules")]
        public ActionResult GetAllSchedules()
        {
            return Ok(dbContext.Schedules.ToList());
        }

        [HttpGet]
        [Route("GetAllScheduleById{id:int}")]
        public ActionResult GetAllScheduleById(int id)
        {
            var schedule = dbContext.Schedules.Find(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return Ok(schedule);
        }

        [HttpGet("GetAllSchedulesWithAdditionalData")]
        public ActionResult GetSchedules() 
        {
            var schedules = dbContext.Schedules
                .Include(st => st.ScheduleType)
                .Include(w => w.Worker)
                .Include(p => p.Pet)
                .Select(s => new Schedule { 
                    Id = s.Id,
                    ScheduleTypeId = s.ScheduleTypeId,
                    ScheduleType = s.ScheduleType,
                    Name = s.Name,
                    Age = s.Age,
                    Past = s.Past,
                    PhoneNumber = s.PhoneNumber,
                    Email = s.Email,
                    Date = s.Date,
                    WorkerId = s.WorkerId,
                    Worker = s.Worker,
                    PetId = s.PetId,
                    Pet = s.Pet,
                    Allergies = s.Allergies,
                    ParentInfo = s.ParentInfo,
                    NumberOfWalker = s.NumberOfWalker,
                    LengthOfWalk = s.LengthOfWalk,
                    Verified = s.Verified
                })
                .ToList();
            return Ok(schedules);
        }

        [HttpPost("AddSchedule")]
        public IActionResult AddSchedule(AddScheduleDto addScheduleDto)
        {
            var scheduleEntity = new Schedule()
            {
                ScheduleTypeId = addScheduleDto.ScheduleTypeId,
                Name = addScheduleDto.Name,
                Age = addScheduleDto.Age,
                Past = addScheduleDto.Past,
                PhoneNumber = addScheduleDto.PhoneNumber,
                Email = addScheduleDto.Email,
                Date = addScheduleDto.Date,
                WorkerId = addScheduleDto.WorkerId,
                PetId = addScheduleDto.PetId,
                Allergies = addScheduleDto.Allergies,
                ParentInfo = addScheduleDto.ParentInfo,
                NumberOfWalker = addScheduleDto.NumberOfWalker,
                LengthOfWalk = addScheduleDto.LengthOfWalk,
                Verified = addScheduleDto.Verified
            };
            dbContext.Schedules.Add(scheduleEntity);
            dbContext.SaveChanges();

            return Ok(scheduleEntity);
        }

        [HttpPut]
        [Route("UpdateSchedule{id:int}")]
        public IActionResult UpdateSchedule(UpdateScheduleDto updateScheduleDto, int id) 
        {
            var schedule = dbContext.Schedules.Find(id);

            if (schedule == null)
            {
                return NotFound();
            }

            schedule.ScheduleTypeId = updateScheduleDto.ScheduleTypeId;
            schedule.Name = updateScheduleDto.Name;
            schedule.Age = updateScheduleDto.Age;
            schedule.Past = updateScheduleDto.Past;
            schedule.PhoneNumber = updateScheduleDto.PhoneNumber;
            schedule.Email = updateScheduleDto.Email;
            schedule.Date = updateScheduleDto.Date;
            schedule.WorkerId = updateScheduleDto.WorkerId;
            schedule.PetId = updateScheduleDto.PetId;
            schedule.Allergies = updateScheduleDto.Allergies;
            schedule.ParentInfo = updateScheduleDto.ParentInfo;
            schedule.NumberOfWalker = updateScheduleDto.NumberOfWalker;
            schedule.LengthOfWalk = updateScheduleDto.LengthOfWalk;
            schedule.Verified = updateScheduleDto.Verified;

            dbContext.SaveChanges();
            return Ok(schedule);
        }

        [HttpDelete]
        [Route("DeleteSchedule{id:int}")]
        public IActionResult DeleteSchedule(int id)
        {
            var schedule = dbContext.Schedules.Find(id);

            if (schedule == null)
            {
                return NotFound();
            }

            dbContext.Schedules.Remove(schedule);
            dbContext.SaveChanges();

            return Ok(schedule);
        }
    }

}
