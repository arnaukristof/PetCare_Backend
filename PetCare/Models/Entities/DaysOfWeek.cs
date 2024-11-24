namespace PetCare.Models.Entities
{
    public class DaysOfWeek
    {
        public required int Id { get; set; }
        public required string NameOfDay { get; set; }

        //Navigation properties
        public List<Worker_DaysOfWeek> Worker_DaysOfWeeks { get; set; }

    }
}
