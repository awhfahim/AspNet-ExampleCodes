using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SamuraiEbook.Application.DTOs;

namespace SamuraiEbook.Api.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IValidator<BookRequestDto> _validator;

        public BookController(IValidator<BookRequestDto> validator)
        {
            _validator = validator;
        }
        [HttpPost("books")]
        public async Task<IActionResult> Post([FromBody] BookRequestDto book)
        {
            var validationResult = await _validator.ValidateAsync(book);
            if(!validationResult.IsValid) return BadRequest(validationResult.Errors);
            return Ok();
        }
    }
}
