#region
using System.Data.Entity;

#endregion

namespace Data
{
    public class SamepleDbContext : DbContext
    {
        public SamepleDbContext() : base("DefaultConnection")
        {
        }

        public SamepleDbContext(string connectionStrgin)
        {
            Database.Connection.ConnectionString = connectionStrgin;
        }

      
        public DbSet<Organisation> Organisations { get; set; }      
        public DbSet<Contact> Contacts { get; set; }
    

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         
          
        }
    }
}