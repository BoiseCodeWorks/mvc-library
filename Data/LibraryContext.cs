using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MVCLibrary.Models;

namespace MVCLibrary
{
    public class LibraryContext : DbContext
    {
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
					optionsBuilder.UseSqlite("Filename=./MVCLibrary.db");
        }

    }
}