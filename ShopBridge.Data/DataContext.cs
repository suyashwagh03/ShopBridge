using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopBridge.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }

    
}
