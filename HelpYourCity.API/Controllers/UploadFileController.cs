using System.Threading.Tasks;
using HelpYourCity.Core.Contracts;
using HelpYourCity.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpYourCity.API.Controllers
{
    [ApiController]
    [Route("api/content")]
    public class UploadFileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public UploadFileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostFile(IFormFile file)
        {
            var response =await _fileService.UploadAsync(file);
            return Ok(response);
        }

    
        
    }
}