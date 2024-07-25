using Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public class MyDbContext : DbContext
    {
        

        public DbSet<Company> company { get; set; } = null!;
        public DbSet<Post> posts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-R70P3QL\SQLEXPRESS;User ID=Shehan;Password=Shehan@97;Encrypt=False;Trust Server Certificate=True");
        }
    }
}
