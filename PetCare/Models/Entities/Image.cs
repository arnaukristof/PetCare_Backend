using System.Reflection.Metadata;

namespace PetCare.Models.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public byte[] Data { get; set; }
        //Foreign key
        public int? PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
