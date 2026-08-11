using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Infrastructure.Data
{
    public class BookStoreDbContext :DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options ): base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
    }
}
