using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandRequest : IRequest<UpdatePostCommandResponse>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
