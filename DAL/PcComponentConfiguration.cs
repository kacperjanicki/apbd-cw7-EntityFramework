using apbd_cw7_EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_cw7_EntityFramework.DAL;

public class PcComponentConfiguration : IEntityTypeConfiguration<PcComponent>
{
    public void Configure(EntityTypeBuilder<PcComponent> builder)
    {
        builder.ToTable("PCComponents");
        builder.HasKey(e => new { e.PcId, e.ComponentCode });

        builder.Property(e => e.ComponentCode)
            .HasMaxLength(10)
            .IsFixedLength()
            .IsUnicode(false);

        builder.Property(e => e.Amount)
            .IsRequired();

        builder.HasOne(e => e.Pc)
            .WithMany(p => p.PcComponents)
            .HasForeignKey(e => e.PcId);

        builder.HasOne(e => e.Component)
            .WithMany(c => c.PcComponents)
            .HasForeignKey(e => e.ComponentCode);

        builder.HasData(
            new PcComponent { PcId = 1, ComponentCode = "I9-14900K", Amount = 1 },
            new PcComponent { PcId = 1, ComponentCode = "RTX4090", Amount = 1 },
            new PcComponent { PcId = 2, ComponentCode = "R9-7950X", Amount = 1 },
            new PcComponent { PcId = 3, ComponentCode = "I9-14900K", Amount = 2 },
            new PcComponent { PcId = 3, ComponentCode = "RX7900XTX", Amount = 2 }
        );
    }
}
