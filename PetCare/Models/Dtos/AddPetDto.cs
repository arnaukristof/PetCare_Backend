namespace PetCare.Models.Dtos
{
    public class AddPetDto
    {
        public required string Name { get; set; }
        public int? Age { get; set; }
        public int PetSizeId { get; set; }
        public int PetTypeId { get; set; }
        public int PetBreedId { get; set; }
        public bool? Medication { get; set; }
        public bool? Indoor { get; set; }
        public string? Description { get; set; }
        public required bool Verified { get; set; }
    }
}
