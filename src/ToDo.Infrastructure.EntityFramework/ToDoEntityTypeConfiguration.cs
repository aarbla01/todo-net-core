using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDo.Infrastructure.EntityFramework
{
    public class ToDoEntityTypeConfiguration : IEntityTypeConfiguration<Core.Entities.ToDo>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.ToDo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(500);
        }
    }
}
