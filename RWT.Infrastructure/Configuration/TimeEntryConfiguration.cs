using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RWT.Domain.User;

namespace RWT.Infrastructure.Configuration;
public class TimeEntryConfiguration : IEntityTypeConfiguration<TimeEntry> {
    public void Configure(EntityTypeBuilder<TimeEntry> builder) {
        builder.ToTable("TimeEntries");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Start).IsRequired();
        builder.Property(x => x.End).IsRequired();
        builder.Property(x => x.Hours).IsRequired();
        builder.Property(x => x.Description).IsRequired().HasMaxLength(TimeEntry.DescriptionMaxLength);
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        builder.Property(x => x.RemovedAt).IsRequired(false);
        builder.HasOne(x => x.User).WithMany(x => x.TimeEntries).HasForeignKey(x => x.UserId);

        builder.HasIndex(x => new { x.UserId, x.Start, x.End }).IsUnique();
        builder.HasIndex(x => new { x.Start, x.End }).IsUnique();

    }
}