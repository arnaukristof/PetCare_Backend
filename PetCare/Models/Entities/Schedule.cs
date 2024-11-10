namespace PetCare.Models.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        //Foreign Key
        public int ScheduleTypeId { get; set; }
        public ScheduleType ScheduleType { get; set; }
        public required string Name { get; set; }
        public int? Age { get; set; }
        public string? Past { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public required string Date { get; set; }
        //Foreign Key
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        //Foreign Key
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public string? Allergies { get; set; }
        public string? ParentInfo { get; set; }
        public int? NumberOfWalker { get; set; }
        public int? LengthOfWalk { get; set; }
        public required bool Verified { get; set; }

    }
}
