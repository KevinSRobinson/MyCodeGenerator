using System.Data.Entity;

namespace Data
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext() : base("DefaultConnection")
        {
        }

        public SampleDbContext(string connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
        }


        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Contact> Contacts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


        }
    }
}