using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Rubrics.Data.Access
{
    public class Context : DbContext
    {
        public IConfiguration Configuration { get; }

        public Context() : base()
        {

        }
        public Context(IConfiguration configuration) : base()
        {
            Configuration = configuration;
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public Context(DbContextOptions<Context> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var conectionString = configuration.GetConnectionString("DefaultConnection");           
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                //    .UseLazyLoadingProxies()
                //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                    .UseSqlServer("Data Source=LAPTOP-JEDG5RJB\\LAPSQLSERVER;Initial Catalog=Rubrics;Integrated Security=False;User Id=sa;Password=fabio1980;MultipleActiveResultSets=True");
            }
        }

        // tables for the database

        public DbSet<Student> Students { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Wine.Data.Wine>().ToTable("Wines");

        //    modelBuilder.Entity<Wine.Data.Country>().ToTable("Countries");

        //    modelBuilder.Entity<Wine.Data.Region>().ToTable("Regions");
        //}
    }
}

