using FileAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FileAPI.Application.Repositories
{
    public interface IReadRepository<T>:IRepository<T>
        where T:BaseEntity
    {
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method,bool tracking=false);
    }
}
