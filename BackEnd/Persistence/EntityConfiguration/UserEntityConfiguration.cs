

using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfiguration
{
    public class UserEntityConfiguration : BaseEntityConfiguration<User>
    {
        public new void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.KeycloakUserId)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(e => e.DisplayName)
            .IsRequired(false)
            .HasMaxLength(500);

            builder.Property(e => e.Email)
            .IsRequired(false)
            .HasMaxLength(500);
        }
    }
}