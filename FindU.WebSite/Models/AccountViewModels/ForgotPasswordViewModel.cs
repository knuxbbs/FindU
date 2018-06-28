﻿using System.ComponentModel.DataAnnotations;

namespace FindU.WebSite.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
