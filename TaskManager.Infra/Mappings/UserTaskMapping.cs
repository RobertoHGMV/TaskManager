using System.Data.Entity.ModelConfiguration;
using TaskManager.Domain.Models.Tasks;

namespace TaskManager.Infra.Mappings
{
    public class UserTaskMapping : EntityTypeConfiguration<UserTask>
    {
        public UserTaskMapping()
        {
            ToTable("UserTask");
            HasKey(c => c.Id);
            Property(c => c.Name).IsRequired().HasMaxLength(200);
            Property(c => c.DateAdd).IsRequired();
        }
    }
}
