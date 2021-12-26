using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Proje.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
          : base(options)
        {
        }
        public DbSet<Books> books { get; set; }
        public DbSet<Messages> messages { get; set; }
    }
}
