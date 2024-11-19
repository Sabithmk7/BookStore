using BookStore.Models;
using BookStore.Models.DTOs;
using BookStore.Services.BookService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookServices;
        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookDTO bookDTO)
        {
            try
            {
                var res = await _bookServices.AddBook(bookDTO);
                if (res != true)
                {
                    return BadRequest("Something went wrong..");
                }
                return Ok("Book Added Succesfully");
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                var res = await _bookServices.GetBooks();
                return Ok(res);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            try
            {
                var res = await _bookServices.GetBookById(id);
                return Ok(res);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
