#region

using Data.Models;
using System.Data.Entity;

#endregion

namespace Data
{
    public class MvYoutContext : DbContext
    {
        public MvYoutContext() : base("MVYouth")
        {
        }

        public MvYoutContext(string connectionStrgin)
        {
            Database.Connection.ConnectionString = connectionStrgin;
        }

      
        public DbSet<Organisation> Organisations { get; set; }      
        public DbSet<User> Users { get; set; }
    

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         
            // modelBuilder.Entity<Item>().HasOptional(r => r.Claims);
          
        }
    }
}