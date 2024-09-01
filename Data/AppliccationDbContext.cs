using System;
using authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace authentication.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=db7074.public.databaseasp.net; Database=db7074; User Id=db7074; Password=s_2DZ7r?o-9Y; Encrypt=False; MultipleActiveResultSets=True;");
        }
        public DbSet<User> Users { get; set; }
    }
}

