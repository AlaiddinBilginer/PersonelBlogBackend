﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.DTOs.Auth
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
