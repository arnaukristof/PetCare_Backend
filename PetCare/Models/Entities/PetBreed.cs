namespace PetCare.Models.Entities
{
    public class PetBreed
    {
        public int Id { get; set; }
        public required string BreedName { get; set; }

        //Navigation properties
        public List<Pet> Pets { get; set; }
    }
}
