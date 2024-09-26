using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryBooksManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBooksManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        LibraryBooksDBContext _context;
        public BookController(LibraryBooksDBContext context)
        {
            _context = context;
        }

        [HttpGet]
       // [Authorize]
        public IActionResult ListOfAllUsers()
        {
            var BookList = _context.Books.ToList();
            return Ok(BookList);

        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult ListOfUserByID(int id)
        {
            var BookList = _context.Books.ToList();
            return Ok(BookList.FirstOrDefault(TempBook => TempBook.BookId == id));
        }

        // POST: api/Book
        [HttpPost]
       [Authorize]
        public IActionResult AddUser([FromBody] BooksInfo TempBook)
        {
            Books XBook = new Books();
            XBook.BookName = TempBook.BookName;
            XBook.BookAuthor = TempBook.BookAuthor;
            XBook.BookCost = TempBook.BookCost;
            XBook.BookIssued = TempBook.BookIssued;
            XBook.BookAvailable = TempBook.BookAvailable;
            _context.Books.Add(XBook);
            _context.SaveChanges();
            return Ok("Added new user " );
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdateUserById(int id, [FromBody]  BooksInfo TempBook)
        {
            Books XBook = _context.Books.FirstOrDefault(B=>B.BookId == id);
            
            XBook.BookName = TempBook.BookName;
            XBook.BookAuthor = TempBook.BookAuthor;
            XBook.BookCost = TempBook.BookCost;
            XBook.BookIssued = TempBook.BookIssued;
            XBook.BookAvailable = TempBook.BookAvailable;
            _context.Books.Update(XBook);
            _context.SaveChanges();
            return Ok("updated user");
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
           Books XBook = _context.Books.FirstOrDefault(B=>B.BookId == id);
            _context.Remove(XBook);
            _context.SaveChanges();
            return Ok("Record Deleted" );
        }
    }
}
