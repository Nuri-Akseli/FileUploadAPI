using FileAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAPI.Domain.Entities
{
    public class User:BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ContainerName { get; set; }
    }
}
