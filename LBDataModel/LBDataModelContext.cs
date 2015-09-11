using System.Data.Entity;
using LBDataModel;

namespace LBDataModel
{
    public class LBDataModelContext : DbContext
    {
        public LBDataModelContext() : base("name=LBDataModelContext")
        {
        }

        public DbSet<Log> Logs { get; set; }

        public DbSet<Machine> Machines { get; set; }

        public DbSet<BackupTask> BackupTasks { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BackupTask>().HasRequired(bt => bt.SourceUser)
                .WithMany(u => u.SourceBackupTasks)
                .HasForeignKey(bt => bt.SourceUserId);

            modelBuilder.Entity<BackupTask>().HasRequired(bt => bt.DestUser)
                .WithMany(u => u.DestBackupTasks)
                .HasForeignKey(bt => bt.DestUserId);
        }
    }
}
