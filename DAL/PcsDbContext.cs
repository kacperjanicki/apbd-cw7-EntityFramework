using apbd_cw7_EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace apbd_cw7_EntityFramework.DAL;

public class PcsDbContext : DbContext
{
    public DbSet<Pc> Pcs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True;Trust Server Certificate=True");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("s33985");
    }
}