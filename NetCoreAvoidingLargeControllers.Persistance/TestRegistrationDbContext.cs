using Microsoft.EntityFrameworkCore;
using NetCoreAvoidingLargeControllers.Domain.Entities;
using NetCoreAvoidingLargeControllers.Domain.Shared;
using NetCoreAvoidingLargeControllers.Persistance.Configurations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreAvoidingLargeControllers.Persistance
{
    public class TestRegistrationDbContext : DbContext
    {

        public TestRegistrationDbContext(DbContextOptions<TestRegistrationDbContext> options) : base(options)
        {

        }

        public DbSet<TestApplicant> TestApplicants { get; set; }

        public DbSet<TestInfo> Tests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TestApplicantConfiguration());
            modelBuilder.ApplyConfiguration(new TestInfoConfiguration());

            modelBuilder.Entity<TestInfo>().HasData(new TestInfo
            {
                ID = 1,
                TestName = "Celpip-G",
                Description = "Celpip Test for english profeciency",
                TestDate = new DateTime(2021, 08, 01)

            });

            modelBuilder.Entity<TestInfo>().HasData(new TestInfo
            {
                ID = 2,
                TestName = "Celpip-LS",
                Description = "Celpip Test for english profeciency",
                TestDate = new DateTime(2021, 10, 01)

            });


            modelBuilder.Entity<TestInfo>().HasData(new TestInfo
            {
                ID = 3,
                TestName = "Azure AZ-900",
                Description = "Azure Fundamentals Certificate",
                TestDate = new DateTime(2021, 11, 01)
            });


            modelBuilder.Entity<TestApplicant>().HasData(new TestApplicant
            {
                ID = 1,
                FirstName = "Ibrahim",
                LastName = "Jaber",
                DateOfBirth = new DateTime(1999, 01, 04),
                TestInfoID = 1
            });

            modelBuilder.Entity<TestApplicant>().HasData(new TestApplicant
            {
                ID = 2,
                FirstName = "Ibrahim",
                LastName = "Jaber",
                DateOfBirth = new DateTime(1999, 06, 26),
                TestInfoID = 2
            });


            modelBuilder.Entity<TestApplicant>().HasData(new TestApplicant
            {
                ID = 3,
                FirstName = "Ali",
                LastName = "Samlioglu",
                DateOfBirth = new DateTime(1999, 09, 22),
                TestInfoID = 2
            });            
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<ModifiableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
