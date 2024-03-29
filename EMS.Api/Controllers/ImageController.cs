using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public ImageController(IHostingEnvironment hostinEnvironment)
        {
            _hostingEnvironment = hostinEnvironment;
        }
        //[Authorize()]
        [HttpGet("view-images")]
        public async Task<IActionResult> ViewImages(string imageName)
        {
            string imagePath = _hostingEnvironment.WebRootPath+"\\images\\"+imageName;
            var image = System.IO.File.OpenRead(imagePath);
            return File(image, "image/png");
        }


        [HttpGet("view-big-images")]
        public async Task<IActionResult> ViewBigImages(string imageName)
        {
            string imagePath = _hostingEnvironment.WebRootPath + "\\images\\model_images\\250\\" + imageName;
            var image = System.IO.File.OpenRead(imagePath);
            return File(image, "image/png");
        }

        [HttpGet("view-small-images")]
        public async Task<IActionResult> ViewSmallImages(string imageName)
        {
            string imagePath = _hostingEnvironment.WebRootPath + "\\images\\model_images\\50\\" + imageName;
            var image = System.IO.File.OpenRead(imagePath);
            return File(image, "image/png");
        }

        [HttpGet("view-service-images")]
        public async Task<IActionResult> ViewServiceImages(string imageName)
        {
            string imagePath = _hostingEnvironment.WebRootPath + "\\images\\service_images\\" + imageName;
            var image = System.IO.File.OpenRead(imagePath);
            return File(image, "image/png");
        }
    }
}