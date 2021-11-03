using System.Data.Entity;
using DataAccess.Models;

namespace DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(string connectionString) 
            : base(connectionString)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
