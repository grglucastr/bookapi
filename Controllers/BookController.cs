using System.Collections.Generic;
using System.Linq;
using BooksApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookApiContext _context;
        
        public BookController(BookApiContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();

            if(_context.Book.Count() == 0)
            {
                Book book = new Book()
                {
                    Title = "Some new cool book",
                    Author = "George L. T. Bentes",
                    Genre = "Cool"
                };

                _context.Book.Add(book);
                _context.SaveChanges();
            }            
        }

        [HttpGet(Name="GetAllBooks")]
        public ActionResult<List<Book>> GetAll()
        {
            return _context.Book.ToList();
        }

        [HttpGet("{id}", Name="GetBook")]
        public ActionResult<Book> GetById(int id)
        {
            Book book = _context.Book.Find(id);
            if(book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            _context.Book.Add(book);
            _context.SaveChanges();
            
            return CreatedAtRoute("GetBook", new {id = book.Id}, book);
        }

        [HttpPut("{id}")]
        public ActionResult<Book> Update(int id, Book book)
        {
            Book dbBook = _context.Book.Find(id);

            if(dbBook == null)
            {
                return NotFound();
            }

            dbBook.Title = book.Title;
            dbBook.Author = book.Author;
            dbBook.Genre = book.Genre;

            _context.Book.Update(dbBook);
            _context.SaveChanges();
            
            return dbBook;
        }

        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            Book dbBook = _context.Book.Find(id);
            if(dbBook == null)
            {
                return NotFound();
            }

            _context.Book.Remove(dbBook);
            _context.SaveChanges();

            return NoContent();
        }

    }
}