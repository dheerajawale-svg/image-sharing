using Microsoft.AspNetCore.Mvc;

namespace SignalRSender.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly ILogger<UploadController> _logger;

        public UploadController(ILogger<UploadController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("ping")]
        public string Ping()
        {
            return "pong";
        }

        [HttpPost]
        public async Task UploadFiles(string dirPath)
        {
            if(string.IsNullOrEmpty(dirPath))
            {
                dirPath = @"C:\Users\dheeraj.awale\Pictures\Wallpapers";
            }

            var allFiles = Directory.GetFiles(dirPath);

            foreach (var file in allFiles)
            {
                var fileStream = System.IO.File.OpenRead(file);

            }
        }
    }
}
