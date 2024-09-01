﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Features.Posts.Commands.DeletePost
{
    public class DeletePostCommandRequest : IRequest<DeletePostCommandResponse>
    {
        public string Id { get; set; }
    }
}
