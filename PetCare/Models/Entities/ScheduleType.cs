namespace PetCare.Models.Entities
{
    public class ScheduleType
    {
        public int Id { get; set; }
        public required string ScheduleTypeName { get; set; }

        //Navigation properties
        public List<Schedule> Schedules { get; set; }
    }
}
