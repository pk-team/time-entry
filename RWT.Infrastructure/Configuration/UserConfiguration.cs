using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RWT.Domain.Models;
using RWT.Domain.User;


namespace RWT.Infrastructure.Configuration {
    public class UserConfiguration : IEntityTypeConfiguration<User> {
        public void Configure(EntityTypeBuilder<User> builder) {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(User.NameMaxLength);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(User.EmailMaxLength);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();
            builder.Property(x => x.RemovedAt).IsRequired(false);

            builder.HasIndex(x => new { x.Email, x.Name }).IsUnique();
            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}