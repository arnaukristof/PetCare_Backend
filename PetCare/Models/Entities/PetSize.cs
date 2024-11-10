namespace PetCare.Models.Entities
{
    public class PetSize
    {
        public int Id { get; set; }
        public required string SizeName { get; set; }

        //Navigation properties
        public List<Pet> Pets { get; set; }
    }
}
