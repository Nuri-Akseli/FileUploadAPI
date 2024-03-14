using FileAPI.Application.Repositories.UserRepositories;
using FileAPI.Domain.Entities;
using FileAPI.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAPI.Persistance.Repositories.UserRepositories
{
    public class UserReadRepository:ReadRepository<User>,IUserReadRepository
    {
        public UserReadRepository(FileAPIDbContext context):base(context)
        {
            
        }
    }
}
