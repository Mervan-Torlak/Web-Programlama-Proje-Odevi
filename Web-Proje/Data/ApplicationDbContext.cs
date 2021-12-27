using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web_Proje.Models;

namespace Web_Proje.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Books> books { get; set; }
        public DbSet<Messages> messages { get; set; }
    }
}
