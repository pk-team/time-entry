using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RWT.Domain.Models.Common;
using RWT.Domain.Clients;

namespace RWT.Infrastructure.Configuration;

public class ClientConfiguration : IEntityTypeConfiguration<Client> {
    public void Configure(EntityTypeBuilder<Client> builder) {
        builder.ToTable("Clients");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Code).HasMaxLength(Client.CodeMaxLength).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(Client.NameMaxLength).IsRequired();
        builder.Property(x => x.TaxId).HasMaxLength(Client.TaxIdMaxLength).IsRequired();
        builder.Property(x => x.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAdd();
        builder.Property(x => x.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP").ValueGeneratedOnAddOrUpdate();
        builder.Property(x => x.RemovedAt).IsRequired(false);
        builder.HasMany(x => x.Todos).WithOne(x => x.Client).HasForeignKey(x => x.ClientId);

        builder.HasIndex(x => x.Code).IsUnique();
        builder.HasIndex(x => x.Name).IsUnique();
        builder.HasIndex(x => x.TaxId).IsUnique();

        // map address as owned entity
        builder.OwnsOne(x => x.Address, address => {
            address.Property(x => x.Street).HasMaxLength(Address.StreetMaxLength).IsRequired();
            address.Property(x => x.City).HasMaxLength(Address.CityMaxLength).IsRequired();
            address.Property(x => x.StateProvince).HasMaxLength(Address.StateProvinceMaxLength).IsRequired();
            address.Property(x => x.Country).HasMaxLength(Address.CountryMaxLength).IsRequired();
            address.Property(x => x.ZipCode).HasMaxLength(Address.ZipCodeMaxLength).IsRequired();
        });
    }
}