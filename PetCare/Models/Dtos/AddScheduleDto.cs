namespace PetCare.Models.Dtos
{
    public class AddScheduleDto
    {
        public int ScheduleTypeId { get; set; }
        public required string Name { get; set; }
        public int? Age { get; set; }
        public string? Past { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public required DateOnly Date { get; set; }
        public int WorkerId { get; set; }
        public int PetId { get; set; }
        public string? Allergies { get; set; }
        public string? ParentInfo { get; set; }
        public int? NumberOfWalker { get; set; }
        public int? LengthOfWalk { get; set; }
        public required bool Verified { get; set; }
    }
}
