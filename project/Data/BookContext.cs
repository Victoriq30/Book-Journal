using Microsoft.EntityFrameworkCore;
using project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Data
{
   public  class BookContext:DbContext
    {
      //  Constructor
        public BookContext()
        {

        }



        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {



        }

        public DbSet<Book> Books { get; set; }
        public DbSet<MyBook> MyBooks { get; set; }
        public DbSet<User> Users { get; set; }

        // Overrides 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer
                    (Configuration.ConnectionString).UseLazyLoadingProxies();
            }



        }



        // Overrides
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
