namespace PetCare.Models.Dtos
{
    public class GetPetDto
    {
        public required string Name { get; set; }
        public int? Age { get; set; }
        public string? PetSize { get; set; }
        public string? PetType { get; set; }
        public string? PetBreed { get; set; }
        public bool? Medication { get; set; }
        public bool? Indoor { get; set; }
        public string? Description { get; set; }
        public int? WorkerId { get; set; }
        public required bool Verified { get; set; }
    }
}
