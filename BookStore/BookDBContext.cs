using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BookStore.Models;

using Microsoft.EntityFrameworkCore;


namespace BookStore
{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions options) : base(options)
        {
          
        }


        public DbSet<BookEntity> BookEntity { get; set; }

        public DbSet<OrderEntity> OrderEntity { get; set; }
    }
}
