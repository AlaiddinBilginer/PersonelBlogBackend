using MediatR;
using Microsoft.AspNetCore.Identity;
using PersonelBlogBackend.Application.DTOs;
using PersonelBlogBackend.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandResponse 
    {
    }

    public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
    {
        public bool Success { get; set; } = true;
        public Token Token { get; set; }
    }

    public class LoginUserErrorCommandResponse : LoginUserCommandResponse
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; }
    }
}
