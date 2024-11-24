namespace PetCare.Models.Entities
{
    public class Worker_DaysOfWeek
    {
        public int Id { get; set; }

        //Navigation properties
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        public int DaysOfWeekId { get; set; }
        public DaysOfWeek DaysOfWeek { get; set; }
    }
}
