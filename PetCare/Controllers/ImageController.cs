using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCare.Data;
using PetCare.Models.Entities;

namespace PetCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ImageController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(/*[FromForm]*/ IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var imageData = memoryStream.ToArray();

                var image = new Image
                {
                    Name = file.FileName,
                    Data = imageData
                };

                dbContext.Images.Add(image);
                await dbContext.SaveChangesAsync();

                return Ok(new { ImageId = image.Id, ImageName = image.Name });
            }
        }

        [HttpPost("UploadImageWithPetId")]
        public async Task<IActionResult> UploadImageWithPetId(/*[FromForm]*/ IFormFile file, int petId)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var imageData = memoryStream.ToArray();

                var image = new Image
                {
                    Name = file.FileName,
                    Data = imageData,
                    PetId = petId
                };

                dbContext.Images.Add(image);
                await dbContext.SaveChangesAsync();

                var imageUrl = Url.Action("GetImage", "Images", new { id = image.Id }, Request.Scheme);
                return Ok(new { ImageId = image.Id, ImageName = image.Name, ImagePetId = image.PetId, ImageUrl = imageUrl });


                //return Ok(new { ImageId = image.Id, ImageName = image.Name, ImagePetId = image.PetId });
            }
        }

        [HttpGet("images/{id}")]
        public IActionResult GetImage(int id)
        {
            var image = dbContext.Images.FirstOrDefault(i => i.Id == id);
            if (image == null)
                return NotFound();

            return File(image.Data, "image/jpeg");  // Return the image as a JPEG file
        }

        [HttpGet("GetImagesByPetId/{petId}")]
        public async Task<IActionResult> GetImagesByPetId(int petId)
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";

            var images = await dbContext.Images
                .Where(img => img.PetId == petId)
                .Select(img => new
                {
                    img.Id,
                    img.Name,
                    ImageUrl = $"{baseUrl}/api/Image/images/{img.Id}" // Manuális URL építés
                })
                .ToListAsync();

            if (!images.Any())
                return NotFound("No images found for the specified PetId.");

            return Ok(images);
        }
    }
}
