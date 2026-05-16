using apbd_cw7_EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_cw7_EntityFramework.DAL;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.ToTable("Components");

        builder.HasKey(e => e.Code);

        builder.Property(e => e.Code)
            .HasMaxLength(10)
            .IsFixedLength()
            .IsUnicode(false);

        builder.Property(e => e.Name)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasColumnType("nvarchar(max)");

        builder.HasOne(e => e.Manufacturer)
            .WithMany(m => m.Components)
            .HasForeignKey(e => e.ComponentManufacturerId);

        builder.HasOne(e => e.ComponentType)
            .WithMany(t => t.Components)
            .HasForeignKey(e => e.ComponentTypeId);

        builder.HasData(
            new Component { Code = "I9-14900K", Name = "Intel Core i9-14900K", Description = "High-end desktop processor", ComponentManufacturerId = 1, ComponentTypeId = 1 },
            new Component { Code = "RX7900XTX", Name = "AMD Radeon RX 7900 XTX", Description = "Flagship AMD graphics card", ComponentManufacturerId = 2, ComponentTypeId = 2 },
            new Component { Code = "RTX4090", Name = "Nvidia GeForce RTX 4090", Description = "Top-tier Nvidia GPU", ComponentManufacturerId = 3, ComponentTypeId = 2 },
            new Component { Code = "R9-7950X", Name = "AMD Ryzen 9 7950X", Description = "16-core workstation CPU", ComponentManufacturerId = 2, ComponentTypeId = 1 }
        );
    }
}
