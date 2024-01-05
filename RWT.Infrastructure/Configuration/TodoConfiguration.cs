using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RWT.Domain.Clients;

namespace RWT.Infrastructure.Configuration;
public class TodoConfiguration : IEntityTypeConfiguration<Todo> {
    public void Configure(EntityTypeBuilder<Todo> builder) {
        builder.ToTable("Todos");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Title).HasMaxLength(Todo.TitleMaxLength).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(Todo.DescriptionMaxLength).IsRequired();
        builder.Property(x => x.Days).IsRequired();
        builder.Property(x => x.StartDate).IsRequired();
        builder.Property(x => x.EndDate).IsRequired();
        builder.Property(x => x.CompletedAt).IsRequired(false);
        builder.Property(x => x.ClientId).IsRequired();
        builder.HasOne(x => x.Client).WithMany(x => x.Todos).HasForeignKey(x => x.ClientId);
    
        builder.HasIndex(x => new { x.ClientId, x.Title }).IsUnique();
    }
}