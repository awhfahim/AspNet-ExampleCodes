﻿namespace StackOverflow.Web.Models.AccountModels
{
    public class LoginModel
    {
		public string Email { get; set; }
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
}