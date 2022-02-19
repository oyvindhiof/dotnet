using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

using System;
using System.Threading.Tasks;

namespace ComicsUniverse.Image.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IHostEnvironment environment;

        public ImagesController(IHostEnvironment environment)
        {
            this.environment = environment;
        }

        /// <summary>
        /// Gets the specified image.
        /// </summary>
        /// <param name="name">The name of the image.</param>
        /// <returns>Returns the image, otherwise NotFound</returns>
        /// <remarks>
        /// YOU need to add error handling!
        /// </remarks>
        [Route("{name}", Name = "GetImageByName")]
        [HttpGet]
        public ActionResult Get(string name)
        {
            string imagePath = GetImagePath();
            string fileName = $"{imagePath}\\{name}";

            if (!System.IO.File.Exists(fileName))
            {
                return NotFound();
            }

            var image = System.IO.File.ReadAllBytes(fileName);

            string extension = new System.IO.FileInfo(fileName).Extension[1..];
            return File(image, $"image/{extension}");
        }

        /// <summary>
        /// Uploads a file.
        /// </summary>
        /// <remarks>Inspired by 
        /// http://www.c-sharpcorner.com/article/uploading-image-to-server-using-web-api-2-0/
        /// Handles ONLY upload of ONE file
        /// 
        /// YOU need to add error handling!
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var file = HttpContext.Request.Form.Files.Count == 1 ? HttpContext.Request.Form.Files[0] : null;

            if (file != null && file.Length > 0)
            {
                string fileName = System.IO.Path.GetFileName(file.FileName);
                string imagePath = GetImagePath();

                using (var outStream = System.IO.File.Create($"{imagePath}\\{fileName}"))
                {
                    await file.CopyToAsync(outStream);
                }

                return CreatedAtRoute("GetImageByName", new { name = fileName }, null);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Deletes the file with the given name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Could not delete file</exception>
        [HttpDelete]
        [Route("{name}", Name = "DeleteImageByName")]
        public IActionResult Delete(string name)
        {
            string imagePath = GetImagePath();
            string fileName = $"{imagePath}\\{name}";

            if (!System.IO.File.Exists(fileName))
            {
                return NotFound();
            }

            try
            {
                System.IO.File.Delete(fileName);
            }
            catch (Exception ex)
            {
                Log(ex);

                return BadRequest("Could not delete file");
            }

            return Ok();
        }

        /// <summary>
        /// Log exception
        /// </summary>
        /// <param name="ex">The exception</param>
        private static void Log(Exception ex)
        {
            // TODO: Add YOUR logging
        }

        /// <summary>
        /// Gets the image path.
        /// </summary>
        /// <returns></returns>
        private string GetImagePath()
        {
            var path = $"{environment.ContentRootPath}\\uploads";

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}
