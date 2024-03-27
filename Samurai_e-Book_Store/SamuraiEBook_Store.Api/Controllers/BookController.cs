using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamuraiEBook_Store.Application.Dtos;
using System.Net;

namespace SamuraiEBook_Store.Api.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IValidator<BookRequestDto> _dtoValidator;

        public BookController(IValidator<BookRequestDto> dtoValidator)
        {
            _dtoValidator = dtoValidator;
        }

        [HttpPost("books")]
        public async Task<IActionResult> Post([FromBody] BookRequestDto book)
        {

            if (book == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid book data");
            }

            //int bookId = CreateBook(book); // Replace with your logic to create the book

            return Created("Post",new { id = 1 });
        }
    }
}
