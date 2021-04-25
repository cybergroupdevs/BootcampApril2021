using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using assignment_net1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment_net1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageDataController : ControllerBase
    {
        StudentDBContext _context;

        public ImageDataController(StudentDBContext context)
        {
            _context = context;
        }

        // GET: api/ImageData
        [HttpGet]
        public IActionResult GetImage()
        {
            ImageInfo img = _context.ImageInfo.ToList();
            string imageBase64Data = Convert.ToBase64String(img.ImgData);
            string imageDataURL =
            string.Format("data:image/jpg;base64,{0}",imageBase64Data);

            return Ok(img);
        }

        // GET: api/ImageData/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetImageById(int id)
        {
            ImageInfo img = _context.ImageInfo.OrderByDescending(i => i.Id).SingleOrDefault();
            string imageBase64Data = Convert.ToBase64String(img.ImgData);
            string imageDataURL =
            string.Format("data:image/jpg;base64,{0}", imageBase64Data);

            return Ok(img);
        }

        // POST: api/ImageData
        [HttpPost]
        public IActionResult AddImage([FromBody] ImageRequest temp)
        {
            ImageInfo img = new ImageInfo();
            img.ImgName = temp.ImgName;

            MemoryStream ms = new MemoryStream();
            temp.CopyTo(ms);
            img.ImgData = ms.ToArray();

            ms.Close();
            ms.Dispose();

            _context.ImageInfo.Add(img);
            _context.SaveChanges();
            return Ok("Image is Uploaded");
        }

        // PUT: api/ImageData/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
