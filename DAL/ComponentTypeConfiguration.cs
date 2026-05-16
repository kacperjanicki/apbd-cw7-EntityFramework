using apbd_cw7_EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_cw7_EntityFramework.DAL;

public class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
{
    public void Configure(EntityTypeBuilder<ComponentType> builder)
    {
        builder.ToTable("ComponentTypes");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Abbreviation)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(e => e.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.HasData(
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Central Processing Unit" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Processing Unit" },
            new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Random Access Memory" },
            new ComponentType { Id = 4, Abbreviation = "SSD", Name = "Solid State Drive" }
        );
    }
}
