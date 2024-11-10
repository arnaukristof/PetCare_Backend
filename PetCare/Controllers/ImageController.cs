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

        [HttpGet("image/{id}")]
        public IActionResult GetImage(int id)
        {
            var image = dbContext.Images.FirstOrDefault(i => i.Id == id);
            if (image == null)
                return NotFound();

            return File(image.Data, "image/jpeg");  // Return the image as a JPEG file
        }


    }
}
