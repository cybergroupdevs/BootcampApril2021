using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentBooks.DbModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        BooksDBContext _context;
        public BooksController(BooksDBContext context)
        {
            _context = context;
        }

        
        // GET: api/Books
        [HttpGet]
        public ActionResult Get()
        {
            var Books = _context.Books.ToList();
            return Ok(Books);
        }

        // GET: api/Books/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult getBook(int id)
        {
            Books Books_one = _context.Books.FirstOrDefault(bk => bk.Id == id);
            return Ok(Books_one);
        }

        // POST: api/Books
        [HttpPost]
        public IActionResult postBook([FromBody]BooksRequest Books)
        {
            Books Books_one = new Books();
            Books_one.Name = Books.Name;
            Books_one.Author = Books.Author;
            _context.Books.Add(Books_one);
            _context.SaveChanges();
            return Ok("Book Added To Database");
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public IActionResult updateBooks(int id, [FromBody]BooksRequest Books)
        {
            Books Books_one = _context.Books.FirstOrDefault(bk => bk.Id == id);
            Books_one.Name = Books.Name;
            Books_one.Author = Books.Author;
            _context.Books.Update(Books_one);
            _context.SaveChanges();
            return Ok("Book Updated");

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult deleteBook(int id)
        {
            var Books_one = _context.Books.FirstOrDefault(bk=> bk.Id ==id);
            _context.Books.Remove(Books_one);
            _context.SaveChanges();
            return Ok("DELETED");
        }
    }
}
