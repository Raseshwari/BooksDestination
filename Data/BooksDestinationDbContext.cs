using BooksDestination.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksDestination.Data
{
    public class BooksDestinationDbContext : DbContext
    {
        public BooksDestinationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BookRepo> BookRepo { get; set; }

        public DbSet<Journals> Journals { get; set; }
    }
}
