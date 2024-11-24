namespace PetCare.Models.Entities
{
    public class Worker
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        //Navigation properties
        public List<Worker_DaysOfWeek> Worker_DaysOfWeeks { get; set; }
        public List<Worker_PetType> Worker_PetTypes { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}