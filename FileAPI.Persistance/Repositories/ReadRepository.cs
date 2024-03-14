using FileAPI.Application.Repositories;
using FileAPI.Domain.Entities.Common;
using FileAPI.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FileAPI.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {

        private readonly FileAPIDbContext _context;
        public ReadRepository(FileAPIDbContext context)
        {
            _context=context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = false)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query.AsNoTracking();

            return await query.FirstOrDefaultAsync(method);
        }
    }
}
