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
            optionsBuilder.UseSqlServer("data source=DESKTOP-PRMBC7J;initial catalog=BlogProject;integrated security=True; MultipleActiveResultSets=True;");
        }

        public DbSet<BlogPost> Blogs { get; set; }
        public DbSet<PostTags> postTags { get; set; }

        public DbSet<BlogPostComments> BlogsComments { get; set; }  
        public DbSet<BlogPostImages> BlogPostImages { get; set; }  
    }
}
