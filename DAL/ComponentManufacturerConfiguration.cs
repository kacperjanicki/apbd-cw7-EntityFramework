using apbd_cw7_EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_cw7_EntityFramework.DAL;

public class ComponentManufacturerConfiguration : IEntityTypeConfiguration<ComponentManufacturer>
{
    public void Configure(EntityTypeBuilder<ComponentManufacturer> builder)
    {
        builder.ToTable("ComponentManufacturers");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Abbreviation)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(e => e.FullName)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(e => e.FoundationDate)
            .HasColumnType("date")
            .IsRequired();

        builder.HasData(
            new ComponentManufacturer { Id = 1, Abbreviation = "INTEL", FullName = "Intel Corporation", FoundationDate = new DateTime(1968, 7, 18) },
            new ComponentManufacturer { Id = 2, Abbreviation = "AMD", FullName = "Advanced Micro Devices", FoundationDate = new DateTime(1969, 5, 1) },
            new ComponentManufacturer { Id = 3, Abbreviation = "NVIDIA", FullName = "Nvidia Corporation", FoundationDate = new DateTime(1993, 4, 5) }
        );
    }
}
