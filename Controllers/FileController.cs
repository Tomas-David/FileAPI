using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly string _filePath = "Uploads";

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Soubor je prázdný");
            }

            var filePath = Path.Combine(_filePath, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetFilesInFoulder()
        {
            var files = Directory.GetFiles(_filePath);
            return Ok(files);
        }

    }
}
