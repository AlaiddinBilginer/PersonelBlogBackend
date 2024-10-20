using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities;
using PersonelBlogBackend.Persistence.Contexts;

namespace PersonelBlogBackend.Persistence.Repositories
{
    public class PostImageWriteRepository : WriteRepository<PostImage>, IPostImageWriteRepository
    {
        public PostImageWriteRepository(PersonelBlogDbContext context) : base(context)
        {
        }
    }
}
