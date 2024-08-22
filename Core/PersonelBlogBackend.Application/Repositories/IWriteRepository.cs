using PersonelBlogBackend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBlogBackend.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        bool Delete(T entity);
        Task<bool> DeleteByIdAsync(string id);
        bool DeleteRange(List<T> entities);
        bool Update(T entity);
        Task<int> SaveAsync();

    }
}
