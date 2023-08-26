using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=DESKTOP-THFGP40;initial catalog=BlogProject;integrated security=True; MultipleActiveResultSets=True;");
        }

        public DbSet<BlogPost> Blogs { get; set; }

        public DbSet<BlogPostComments> BlogsComments { get; set; }  
    }
}
