

using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration
{
    public class ActivityEntityConfiguration : BaseEntityConfiguration<Activity>
    {
        public new void Configure(EntityTypeBuilder<Activity> builder)
        {
            base.Configure(builder);

            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(a => a.Category)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(a => a.EventDate)
                .IsRequired();

            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(180);

            builder.Property(a => a.Venue)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(a => a.Latitude)
                .IsRequired()
                .HasColumnType("bigint");

            builder.Property(a => a.Longitude)
                .IsRequired()
                .HasColumnType("bigint");
        }
    }
}
