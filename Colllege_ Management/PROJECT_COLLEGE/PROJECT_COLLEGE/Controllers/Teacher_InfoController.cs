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
    public class Teacher_InfoController : ControllerBase
    {
        CollegedbContext _context;


        public Teacher_InfoController(CollegedbContext context)
        {
            _context = context;
        }



        [HttpGet]
        public ActionResult GetAllTeachers()
        {
            var TeacherList = _context.TeacherTbl.ToList();
            return Ok(TeacherList);
        }
        [HttpPost]
        public ActionResult AddTeacher([FromBody] TeacherTbl teacher)
        {
            _context.TeacherTbl.Add(teacher);
            _context.SaveChanges();
            return Ok("Teacher Details Added successfully");
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteTeacher(int id)
        {
            var teacherInfo = _context.TeacherTbl.FirstOrDefault(student => student.TeacherId == id);
            _context.TeacherTbl.Remove(teacherInfo);
            _context.SaveChanges();
            return Ok(teacherInfo);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateTeacher(int id, [FromBody] TeacherTbl teacherRequest)
        {
            TeacherTbl teacherInfo = _context.TeacherTbl.FirstOrDefault(teacher => teacher.TeacherId == id);
            teacherInfo.TeacherName = teacherRequest.TeacherName;
            teacherInfo.TeacherPhone = teacherRequest.TeacherPhone;
            teacherInfo.TeacherGender = teacherRequest.TeacherGender;
           teacherInfo.TeacherDep = teacherRequest.TeacherDep;
            teacherInfo.TeacherAdd = teacherRequest.TeacherAdd;

            _context.TeacherTbl.Update(teacherInfo);
            _context.SaveChanges();
            return Ok(teacherInfo);
        }
    }
}
