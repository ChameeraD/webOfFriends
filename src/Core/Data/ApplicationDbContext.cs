using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Data

{
    public class ApplicationDbContext:DbContext 
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<BestFriend> BestFriends { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyClass> SurveyClasses { get; set; }
        public DbSet<SurveyRecord> SurveyRecords { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasOne(p => p.SchoolClass)
                .WithOne(i => i.Teacher)
                .HasForeignKey<SchoolClass>(b => b.TecherId);

            // set delete behavior
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().Where(e => !e.IsOwned()).SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is BaseEntity baseEntity)
                {
                    var now = DateTime.UtcNow;
                    //var user = GetCurrentUser();
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            baseEntity.LastUpdated = now;
                            //baseEntity.LastUpdatedBy = user;
                            break;

                        case EntityState.Added:
                            baseEntity.Created = now;
                            //baseEntity.CreatedBy = user;
                            baseEntity.LastUpdated = now;
                            //baseEntity.LastUpdatedBy = user;
                            break;
                    }
                }
            }
        }
    }
}
