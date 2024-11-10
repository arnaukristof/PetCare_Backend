namespace PetCare.Models.Entities
{
    public class PetType
    {
        public int Id { get; set; }
        public required string TypeName { get; set; }

        //Navigation properties
        public List<Pet> Pets { get; set; }
        public List<Worker_PetType> Worker_PetTypes { get; set; }
    }
}
