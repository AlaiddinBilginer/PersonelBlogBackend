using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.DTOs.Comments
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}
