namespace PetCare.Models.Dtos
{
    public class CreateWorker
    {
        public string Name { get; set; }
        public List<int> PetTypeIds { get; set; }
        public List<int> DaysOfWeeksIds { get; set; }
    }
}
