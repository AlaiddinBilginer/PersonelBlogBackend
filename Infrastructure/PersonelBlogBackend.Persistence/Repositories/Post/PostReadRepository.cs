using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities;
using PersonelBlogBackend.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Persistence.Repositories
{
    public class PostReadRepository : ReadRepository<Post>, IPostReadRepository
    {
        public PostReadRepository(PersonelBlogDbContext context) : base(context)
        {
        }
    }
}
