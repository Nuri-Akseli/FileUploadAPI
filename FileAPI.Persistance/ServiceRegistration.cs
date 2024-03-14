using FileAPI.Application.Repositories.UserRepositories;
using FileAPI.Persistance.Context;
using FileAPI.Persistance.Repositories.UserRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAPI.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<FileAPIDbContext>(options=>options.UseMySQL(Configuration.ConnectionString));

            services.AddScoped<IUserReadRepository, UserReadRepository>();
        }
    }
}
