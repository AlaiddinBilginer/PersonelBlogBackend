using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities;
using PersonelBlogBackend.Persistence.Contexts;

namespace PersonelBlogBackend.Persistence.Repositories
{
    internal class TagReadRepository : ReadRepository<Tag>, ITagReadRepository
    {
        public TagReadRepository(PersonelBlogDbContext context) : base(context)
        {
        }
    }
}
