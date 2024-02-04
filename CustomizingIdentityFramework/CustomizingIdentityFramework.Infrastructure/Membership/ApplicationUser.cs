using Microsoft.AspNetCore.Identity;
using System;

namespace CustomizingIdentityFramework.Infrastructure.Membership
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
