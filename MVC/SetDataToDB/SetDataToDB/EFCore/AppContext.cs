using Microsoft.EntityFrameworkCore;
using SetDataToDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetDataToDB.EFCore
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        private string ConnectionString { get; set; }

        public AppContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
