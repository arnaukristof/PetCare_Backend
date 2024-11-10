namespace PetCare.Models.Entities
{
    public class Worker_PetType
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public Worker Worker { get; set; }
        public int PetTypeId { get; set; }
        public PetType PetType { get; set; }
    }
}
