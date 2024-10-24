﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandRequest : IRequest<RefreshTokenCommandResponse>
    {
        public string RefreshToken { get; set; }
    }
}
