using System.Data.Entity;
using DataAccess.Models;

namespace DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() 
            : base(@"data source=DESKTOP-D1BVDQU;Initial Catalog=MoneyAccounting;Integrated Security=True;")
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
