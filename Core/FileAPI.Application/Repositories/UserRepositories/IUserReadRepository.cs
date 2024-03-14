using FileAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAPI.Application.Repositories.UserRepositories
{
    public interface IUserReadRepository:IReadRepository<User>
    {
    }
}
