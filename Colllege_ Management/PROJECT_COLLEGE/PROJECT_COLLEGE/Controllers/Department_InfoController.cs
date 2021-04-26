using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJECT_COLLEGE.Models;

namespace PROJECT_COLLEGE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Department_InfoController : ControllerBase
    {
        // GET: api/Department_Info
        CollegedbContext _context;


        public Department_InfoController(CollegedbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public ActionResult GetAllDepartments()
        {
            var departmenttList = _context.DepartmentTbl.ToList();
            return Ok(departmenttList);
        }
        [HttpPost]
        public ActionResult AddDepartment([FromBody] DepartmentTbl dept)
        {
            _context.DepartmentTbl.Add(dept);
            _context.SaveChanges();
            return Ok("Department Details Added successfully");
        }
        [HttpDelete("{name}")]
        public ActionResult DeleteDepartment(String name)
        {
            var studentInfo = _context.DepartmentTbl.FirstOrDefault(student => student.DepName == name);
            _context.DepartmentTbl.Remove(studentInfo);
            _context.SaveChanges();
            return Ok(studentInfo);
        }
        [HttpPut("{name}")]
        public ActionResult UpdateDepartment(String name, [FromBody] DepartmentTbl deaprtmentRequest)
        {
            DepartmentTbl departmentInfo = _context.DepartmentTbl.FirstOrDefault(student => student.DepName == name);
            departmentInfo.DepDesc = deaprtmentRequest.DepDesc;
            departmentInfo.DepDuration= deaprtmentRequest.DepDuration;


            _context.DepartmentTbl.Update(departmentInfo);
            _context.SaveChanges();
            return Ok(departmentInfo);
        }
    }
}
