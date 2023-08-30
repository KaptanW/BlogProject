using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=DESKTOP-THFGP40;initial catalog=BlogProject;integrated security=True; MultipleActiveResultSets=True;");
        }

        public DbSet<BlogPost> Blogs { get; set; }
        public DbSet<PostTags> postTags { get; set; }

        public DbSet<BlogPostComments> BlogsComments { get; set; }  
        public DbSet<BlogPostImages> BlogPostImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // BlogComments tablosu için FOREIGN KEY ilişkisini yapılandırma
            modelBuilder.Entity<BlogPostComments>()
                .HasOne(bc => bc.User)
                .WithMany()
                .HasForeignKey(bc => bc.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Kısıtlamayı 'NO ACTION' veya 'CASCADE' olarak ayarlayın

            // Diğer FOREIGN KEY ilişkilerini de benzer şekilde yapılandırabilirsiniz.
        }
    }
}
