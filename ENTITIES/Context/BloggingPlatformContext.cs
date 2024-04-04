using ENTITIES.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Context
{
    public class BloggingPlatformContext : DbContext
    {
        //Create the contructor
        public BloggingPlatformContext() : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=BloggingPlatform;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

    }
}
