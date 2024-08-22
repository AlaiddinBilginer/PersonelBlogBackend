using PersonelBlogBackend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Title { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
