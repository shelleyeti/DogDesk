using Microsoft.AspNetCore.Http;

namespace DogDesk.Models
{
    public class PetImage
    {
        public IFormFile ImageFile { get; set; }
        public int PetId { get; set; }
    }
}
