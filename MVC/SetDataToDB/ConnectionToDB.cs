using Microsoft.EntityFrameworkCore;
using SetDataToDB.Models;

public class ConnectionToDB : DbContext
{
    public DbSet<User> Users { get; set; }
    private string ConnectionString { get; set; }

    public AppContext(string connectionString)
    {
        ConnectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }
}
