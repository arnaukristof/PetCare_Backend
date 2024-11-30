namespace PetCare.Models.Dtos
{
    public class CreateWorkerDto
    {
        public string Name { get; set; } = string.Empty;
        public List<int> PetTypeIds { get; set; } = new List<int>();
        public List<int> DaysOfWeekIds { get; set; } = new List<int>();
    }
}
