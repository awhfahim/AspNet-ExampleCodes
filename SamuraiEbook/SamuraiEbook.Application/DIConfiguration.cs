using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SamuraiEbook.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiEbook.Application
{
    public static class DIConfiguration
    {
        public static void ConfigureFluentServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<BookRequestDtoValidator>();
        }
    }
}
