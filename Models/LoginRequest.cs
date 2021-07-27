﻿using System.ComponentModel.DataAnnotations;

namespace Kinoshka.Models
{
    public class LoginRequest
    {
        [Required] [Display(Name = "Email")] public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")] public bool RememberMe { get; set; }
    }
}