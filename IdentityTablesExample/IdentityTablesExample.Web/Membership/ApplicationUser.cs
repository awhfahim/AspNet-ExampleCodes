using Microsoft.AspNetCore.Identity;
using System;

namespace FirstDemo.Infrastructure.Membership
{
    public class ApplicationUser : IdentityUser<Guid>
    {

        public Guid UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
