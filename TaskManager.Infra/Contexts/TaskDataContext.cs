using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TaskManager.Domain.Models.Tasks;
using TaskManager.Infra.Mappings;
using TaskManager.Shared;

namespace TaskManager.Infra.Contexts
{
    public class TaskDataContext : DbContext
    {
        public TaskDataContext() : base(Runtime.ConnectionString)
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<UserTask> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TaskDataContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<TaskDataContext, Configuration>()); //Migration

            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserTaskMapping());
        }
    }
}
