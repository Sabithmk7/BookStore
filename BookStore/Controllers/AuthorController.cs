using BookStore.Models;
using BookStore.Models.DTOs;
using BookStore.Services.AuthorService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorServices _authorServices;
        public AuthorController(IAuthorServices authorServices)
        {
            _authorServices = authorServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(AddAuthorDTO addAuthor)
        {
            try
            {
                var res = await _authorServices.AddAuthor(addAuthor);
                if (res != true)
                {
                    return BadRequest("Some error occured");
                }
                return Ok("Author Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            try
            {
                var res = await _authorServices.GetAuthors();
                return Ok(res);
            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
