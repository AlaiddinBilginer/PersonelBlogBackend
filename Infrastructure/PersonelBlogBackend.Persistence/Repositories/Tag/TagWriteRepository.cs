using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities;
using PersonelBlogBackend.Persistence.Contexts;

namespace PersonelBlogBackend.Persistence.Repositories
{
    public class TagWriteRepository : WriteRepository<Tag>, ITagWriteRepository
    {
        public TagWriteRepository(PersonelBlogDbContext context) : base(context)
        {
        }
    }
}
