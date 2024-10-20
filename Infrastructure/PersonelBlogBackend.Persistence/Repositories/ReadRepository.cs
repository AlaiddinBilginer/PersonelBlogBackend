using Microsoft.EntityFrameworkCore;
using PersonelBlogBackend.Application.Repositories;
using PersonelBlogBackend.Domain.Entities.Common;
using PersonelBlogBackend.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly PersonelBlogDbContext _context;
        public ReadRepository(PersonelBlogDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            if (!Guid.TryParse(id, out var guidId))
                throw new ArgumentException("Invalid Guid format", nameof(id));

            var query = Table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(data => data.Id == guidId);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if(!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true)
        {
            var query = Table.Where(predicate);

            if(!tracking)
                query = query.AsNoTracking();

            return query;
        }
    }
}
