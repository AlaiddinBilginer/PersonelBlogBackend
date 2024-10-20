using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities;
using PersonelBlogBackend.Persistence.Contexts;

namespace PersonelBlogBackend.Persistence.Repositories
{
    public class PostImageReadRepository : ReadRepository<PostImage>, IPostImageReadRepository
    {
        public PostImageReadRepository(PersonelBlogDbContext context) : base(context)
        {
        }
    }
}
