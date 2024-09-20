using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.DTOs.Auth
{
    public class AuthResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public Token Token { get; set; }
    }
}
