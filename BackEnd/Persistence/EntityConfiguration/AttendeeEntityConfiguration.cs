

using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration
{
    public class AttendeeEntityConfiguration : IEntityTypeConfiguration<Attendee>
    {
        public void Configure(EntityTypeBuilder<Attendee> builder)
        {
            builder.ToTable(nameof(Attendee));

            builder.HasOne(e => e.User)
            .WithMany(u => u.Attendees)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

            builder.HasOne(e => e.Activity)
            .WithMany(a => a.Attendees)
            .HasForeignKey(e => e.ActivityId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

            builder.Property(e => e.IsHost)
            .IsRequired();

            builder.Property(e => e.DateJoined)
            .IsRequired();
        }
    }
}