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
        [HttpPut("{authorId}")]
        public async Task<IActionResult> UpdateAuthor(Guid authorId, [FromBody] AddAuthorDTO addAuthor)
        {
            try
            {
                var res = await _authorServices.UpdateAuthor(authorId, addAuthor);
                if(res != true)
                {
                    return BadRequest("Updation failed");
                }
                return Ok("Updated succesfully");
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{authorId}")]
        public async Task<IActionResult> GetAuthorById(Guid authorId)
        {
            try
            {
                var res = await _authorServices.GetAuthorById(authorId);
                if (res == null)
                {
                    return NotFound("Author Not found");
                }
                return Ok(res);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{authorId}")]
        public async Task<IActionResult> DeleteAuthor(Guid authorId)
        {
            try
            {
                var res = await _authorServices.DeleteAuthor(authorId);
                if (res != true)
                {
                    return BadRequest("Something went wrong");
                }
                return Ok("Author deleted succesfully");
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
