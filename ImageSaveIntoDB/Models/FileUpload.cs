using Microsoft.AspNetCore.Http;

namespace ImageSaveIntoDB.Models
{
    public class FileUpload
    {
        public IFormFile file { get; set; }

        public string Student { get; set; }    
    }
}
