using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuotesAPI2.Models;

namespace QuotesAPI2.Data
{
    public class QuotesDbContext : DbContext
    {

        public QuotesDbContext(DbContextOptions<QuotesDbContext>options) : base (options)
        {
            
        }

        public DbSet<Quote> Quotes { get; set; }
    }
}
