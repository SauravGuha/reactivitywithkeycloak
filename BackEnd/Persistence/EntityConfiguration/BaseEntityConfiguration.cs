

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration
{
    public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey("Id");
            builder.Property<DateTime>("CreatedAt")
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();
            builder.Property<DateTime>("UpdatedAt")
                .HasDefaultValueSql("GETUTCDATE()")
                .IsRequired();
        }
    }
}
