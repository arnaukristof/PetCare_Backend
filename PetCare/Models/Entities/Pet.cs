using System.ComponentModel.DataAnnotations;

namespace PetCare.Models.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int? Age { get; set; }
        //Foreign Key
        public int PetSizeId { get; set; }
        public PetSize PetSize { get; set; }
        //Foreign Key
        public int PetTypeId { get; set; }
        public PetType PetType { get; set; }
        //Foreign Key
        public int PetBreedId { get; set; }
        public PetBreed PetBreed { get; set; }
        public bool? Medication { get; set; }
        public bool? Indoor { get; set; }
        public string? Description { get; set; }
        public required bool Verified { get; set; }

        //Navigation Properties
        public List<Schedule> Schedules { get; set; }
        public List<Image> Images { get; set; }
    }
}
