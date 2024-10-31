using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandResponse
    {
    }

    public class CreatePostCommandSuccessResponse : CreatePostCommandResponse
    {
        public bool Succeeded { get; set; } = true;
        public Guid Id { get; set; }
    }

    public class CreatePostCommandErrorResponse : CreatePostCommandResponse
    {
        public bool Succeeded { get; set; } = false;
        public string Message { get; set; }
    }
}
