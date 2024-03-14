using FileAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAPI.Persistance.Context
{
    public class FileAPIDbContext:DbContext
    {
        public FileAPIDbContext(DbContextOptions contextOptions):base(contextOptions)
        {
            
        }
        DbSet<User> Users { get; set; }
    }
}
