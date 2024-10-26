using PersonelBlogBackend.Domain.Entities.Common;
using PersonelBlogBackend.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}
