using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment_net1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment_net1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationDataController : ControllerBase
    {

        StudentDBContext _context;
        public EducationDataController(StudentDBContext context)
        {
            _context = context;
        }
       
        // GET: api/EducationData
        [HttpGet]
        public IActionResult GetEducationData()
        {
            var EducationList = _context.EducationInfo.ToList();
            return Ok(EducationList);
        }

        // GET: api/EducationData/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetEducationById(int id)
        {
            var edu = _context.EducationInfo.FirstOrDefault(EducationInfo => EducationInfo.Id == id);
            return Ok(edu);
        }

        // POST: api/EducationData
        [Authorize]
        [HttpPost]
        public IActionResult AddEducation([FromBody] EducationRequest temp)
        {
            EducationInfo edu = new EducationInfo();
            edu.Year = temp.Year;
            edu.Qualification = temp.Year;
            edu.SchoolName = temp.SchoolName;
            edu.Grade = temp.Grade;
            _context.EducationInfo.Add(edu);
            _context.SaveChanges();
            return Ok("Data Added Successfully");
        }

        // PUT: api/EducationData/5
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateEducation(int id, [FromBody] EducationRequest temp)
        {
            EducationInfo eduInfo = _context.EducationInfo.FirstOrDefault(edu => edu.Id == id);
            eduInfo.Year = temp.Year;
            eduInfo.Qualification = temp.Qualification;
            eduInfo.SchoolName = temp.SchoolName;
            eduInfo.Grade = temp.Grade;
            _context.EducationInfo.Update(eduInfo);
            _context.SaveChanges();
            return Ok("Data is Updated");
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult RemoveEducation(int id)
        {
            var edu = _context.EducationInfo.FirstOrDefault(Edu => Edu.Id == id);
            _context.EducationInfo.Remove(edu);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
