using Core_Project_Apii.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core_Project_Apii.DAL.ApiContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=SULEYMAN;database=CoreProjectDB2;integrated security=true;TrustServerCertificate=True");

        }

        public DbSet<Category> Categories { get; set; }
    }
}
