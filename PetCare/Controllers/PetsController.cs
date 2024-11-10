using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCare.Data;
using PetCare.Models.Dtos;
using PetCare.Models.Entities;
using System.Net.Cache;

namespace PetCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public PetsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("GetAllPets")]
        public ActionResult GetAllPets()
        {
            return Ok(dbContext.Pets.ToList());
        }

        [HttpGet]
        [Route("GetAllPetById{id:int}")]
        public ActionResult GetAllPetById(int id)
        {
            var pet = dbContext.Pets.Find(id);

            if (pet == null) 
            {
                return NotFound();
            }

            return Ok(pet);
        }

        [HttpGet("GetAllPetsWithAdditionalData")]
        public IActionResult GetPets()
        {
            var pets =  dbContext.Pets
                .Include(ps => ps.PetSize)
                .Include(ps => ps.PetType)
                .Include(ps => ps.PetBreed)
                .Select(p => new Pet { 
                    Id = p.Id,
                    Name = p.Name,
                    Age = p.Age,
                    PetSizeId=p.PetSizeId,
                    PetSize = p.PetSize,
                    PetTypeId = p.PetTypeId,
                    PetType = p.PetType,
                    PetBreedId = p.PetBreedId,
                    PetBreed = p.PetBreed,
                    Medication = p.Medication,
                    Indoor = p.Indoor,
                    Description = p.Description,
                    Verified = p.Verified


                })
                .ToList();
            return Ok(pets);
        }

        [HttpPost("AddPet")]
        public IActionResult AddPet(AddPetDto addPetDto)
        {
            var petEntity = new Pet()
            {
                Name = addPetDto.Name,
                Age = addPetDto.Age,
                PetSizeId = addPetDto.PetSizeId,
                PetTypeId = addPetDto.PetTypeId,
                PetBreedId = addPetDto.PetBreedId,
                Medication = addPetDto.Medication,
                Indoor = addPetDto.Indoor,
                Description = addPetDto.Description,
                WorkerId = addPetDto.PetSizeId,
                Verified = addPetDto.Verified
            };

            dbContext.Pets.Add(petEntity);
            dbContext.SaveChanges();

            return Ok(petEntity);
        }

        [HttpPut]
        [Route("UpdatePet{id:int}")]
        public IActionResult UpdatePets(UpdatePetDto updatePetDto, int id)
        {
            var pet = dbContext.Pets.Find(id);

            if (pet == null) 
            { 
                return NotFound(); 
            }

            pet.Name = updatePetDto.Name;
            pet.Age = updatePetDto.Age;
            pet.PetSizeId = updatePetDto.PetSizeId;
            pet.PetTypeId = updatePetDto.PetTypeId;
            pet.PetBreedId = updatePetDto.PetBreedId;
            pet.Medication = updatePetDto.Medication;
            pet.Indoor = updatePetDto.Indoor;
            pet.Description = updatePetDto.Description;
            pet.WorkerId = updatePetDto.WorkerId;
            pet.Verified = updatePetDto.Verified;

            dbContext.SaveChanges();
            return Ok(pet);
        }

        [HttpDelete]
        [Route("DeletePet{id:int}")]
        public IActionResult DeletePet(int id) 
        {
            var pet = dbContext.Pets.Find(id);

            if (pet == null) 
            {
                return NotFound(); 
            }
            
            dbContext.Pets.Remove(pet);
            dbContext.SaveChanges();

            return Ok(pet);
        }
    }
}
