﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Features.Auth.Commands.LoginUser
{
    public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
    {
        public string EmailOrUsername { get; set; }
        public string Password { get; set; }
    }
}