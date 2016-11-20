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

        public DbSet<HourRecord> HourRecords { get; set; }
        public DbSet<MvUser> MvUsers { get; set; }
        public DbSet<WhereIVolunteer> WhereIVolunteers { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<PlanOfAction> PlanOfActions { get; set; }
        public DbSet<SelfAssessment> SelfAssessments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<ValidateSkill> ValidateSkills { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HourRecord>().HasKey(x => x.Id);


            // modelBuilder.Entity<Item>().HasOptional(r => r.Claims);
            // modelBuilder.Entity<ItemClaim>().HasRequired(r => r.Item);
            //modelBuilder.Entity<Gamification>().HasRequired(r => r.ApplicationUser);
        }
    }
}