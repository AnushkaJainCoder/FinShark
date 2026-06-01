using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }
        public DbSet<StockModel> Stocks { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        
    }
}