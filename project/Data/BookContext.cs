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
        public BookContext()
        {

        }

        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<MyBook> MyBooks { get; set; }
        public virtual DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer
                    (Configuration.ConnectionString).UseLazyLoadingProxies();
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
