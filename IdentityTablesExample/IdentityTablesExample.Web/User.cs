﻿namespace IdentityTablesExample.Web
{
    public class User
    {
        public Guid Id { get; set; }
        public string? DisplayName { get; set; }
        public string? FullName { get; set; }
        public string? Location { get; set; }
        public string? AboutMe { get; set; }
        public string? WebsiteLink { get; set; }
        public string? TwitterUsername { get; set; }
        public string? GitHubUsername { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}