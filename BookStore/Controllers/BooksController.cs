using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using BookStore.Models;
using BookStore.Services;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    [Route("Books")]
    [Authorize]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IConfigurationProvider myMapperConfigurationProvider;
        private readonly IBookService myBookService;

        public BooksController(IConfigurationProvider configurationProvider , IBookService bookService)
        {
            myMapperConfigurationProvider = configurationProvider;
            myBookService = bookService;
        }

        // GET: api/<BookController>
        [HttpGet(Name = nameof(GetAllBooks))]
        [Route("GetAllBooks")]
        [ProducesResponseType(200)]
        public ActionResult<List<Book>> GetAllBooks()
        {

            var bookList = myBookService.GetAllBooks();
            return Ok(bookList);
        }

        [HttpGet(Name = nameof(GetBookById))]
        [Route("GetBooksById")]
        [ProducesResponseType(200)]
        public ActionResult<Book> GetBookById([FromQuery] string bookId)
        {

            var book = myBookService.GetBookById(Guid.Parse(bookId));
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}
