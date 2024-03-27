using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiEbook.Application.DTOs
{
    public class BookRequestDtoValidator : AbstractValidator<BookRequestDto>
    {
        public BookRequestDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Author).NotEmpty().WithMessage("Author is required");
            RuleFor(x => x.Genre).NotEmpty().WithMessage("Genre is required");
            RuleFor(x => x.Price).NotEmpty().GreaterThanOrEqualTo(100).WithMessage("Price is required");
        }
    }
}
