using PersonelBlogBackend.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandResponse
    {
        
    }

    public class RefreshTokenCommandSuccessResponse : RefreshTokenCommandResponse
    {
        public bool Succeeded { get; set; }
        public Token Token { get; set; }
    }

    public class RefreshTokenCommandErrorResponse : RefreshTokenCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
