﻿using System.ComponentModel.DataAnnotations;

namespace Practice1.Web.Models
{
    public class TestModel
    {
        [Required, EmailAddress(ErrorMessage = "Please provide valid email"), Display(Name = "Email Address")]
        public string? Email { get; set; }
        //[RegularExpression("", ErrorMessage = "")]
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
