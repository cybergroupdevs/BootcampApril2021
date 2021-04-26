using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testProject.Models;

namespace testProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {

        StudentdBContext _context;
        public QueryController(StudentdBContext context)

        {
            _context = context;
        }

        // POST: api/Query
        [HttpPost]
        public ActionResult AddQuery([FromBody] QueryRequest queryRequest)
        {
            Query query = new Query()
            {
                Email = queryRequest.Email,
                College = queryRequest.College,
                
                Issue = queryRequest.Issue

            };

            _context.Query.Add(query);
            _context.SaveChanges();
            return Ok("Query Added");
        }

       
    }
}
