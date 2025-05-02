using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<WriterUser,WriterRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

<<<<<<< HEAD
            //optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER2022;Database=sule1877_CoreProjectDB;User Id=sule1877_user01;Password=tTTp0ng2%;TrustServerCertificate=True;");
            optionsBuilder.UseSqlServer("server=SULEYMAN;database=CoreProjectDB;integrated security=true;TrustServerCertificate=True");
=======
            optionsBuilder.UseSqlServer("---");
>>>>>>> 7d3bcd5cf43df805303278596ae846ec5b9fe5ad


        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<Education> Educations{ get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Feature> Features{ get; set; }
        public DbSet<Message> Messages{ get; set; }
        public DbSet<Portfolio> Portfolios{ get; set; }
        public DbSet<Service> Services{ get; set; }
        public DbSet<Skill> Skills{ get; set; }
        public DbSet<SocialMedia> SocialMedias{ get; set; }
        public DbSet<Testimonial> Testimonials{ get; set; }
        public DbSet<Todolist> Todolist{ get; set; }
        public DbSet<Announcements> Announcements{ get; set; }
        public DbSet<WriterMessage> WriterMessage{ get; set; }
        public DbSet<Documents> Documents{ get; set; }

    }
}


