using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Infrastructure;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<PCs> PCs { get; set; }
    public DbSet<PCComponents> PCComponents { get; set; }
    public DbSet<Components> Components { get; set; }
    public DbSet<ComponentTypes> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        var seedDate = new DateTime(2026, 05, 18, 12, 0, 0);
        
        modelBuilder.Entity<ComponentTypes>().HasData(
            new ComponentTypes { Id = 1, Abbreviation = "CPU", Name = "Processor" },
            new ComponentTypes { Id = 2, Abbreviation = "GPU", Name = "Graphics Card" },
            new ComponentTypes { Id = 3, Abbreviation = "RAM", Name = "Memory" }
        );

        modelBuilder.Entity<ComponentManufacturers>().HasData(
            new ComponentManufacturers { Id = 1, Abbreviation = "INT", FullName = "Intel", FoundationDate = new DateOnly(1968, 7, 18) },
            new ComponentManufacturers { Id = 2, Abbreviation = "NVI", FullName = "NVIDIA", FoundationDate = new DateOnly(1993, 4, 5) },
            new ComponentManufacturers { Id = 3, Abbreviation = "COR", FullName = "Corsair", FoundationDate = new DateOnly(1994, 1, 1) }
        );

        modelBuilder.Entity<Components>().HasData(
            new Components { Code = "I9-13900K", Name = "Intel Core i9", ComponentTypesId = 1, ComponentManufacturersId = 1, Description = "High-end CPU" },
            new Components { Code = "RTX-4080", Name = "NVIDIA RTX 4080", ComponentTypesId = 2, ComponentManufacturersId = 2, Description = "Powerful GPU" },
            new Components { Code = "VENG-32GB", Name = "Corsair Vengeance DDR5", ComponentTypesId = 3, ComponentManufacturersId = 3, Description = "Fast RAM" }
        );

        modelBuilder.Entity<PCs>().HasData(
            new PCs { Id = 1, Name = "Gaming Beast", Weight = 12.5f, Warranty = 24, CreatedAt = seedDate, Stock = 5 },
            new PCs { Id = 2, Name = "Office Workstation", Weight = 8.0f, Warranty = 12, CreatedAt = seedDate, Stock = 10 },
            new PCs { Id = 3, Name = "Streaming Rig", Weight = 15.2f, Warranty = 36, CreatedAt = seedDate, Stock = 3 }
        );

        modelBuilder.Entity<PCComponents>().HasData(
            new PCComponents { PCId = 1, ComponentCode = "I9-13900K", Amount = 1 },
            new PCComponents { PCId = 1, ComponentCode = "RTX-4080", Amount = 1 },
            new PCComponents { PCId = 2, ComponentCode = "VENG-32GB", Amount = 2 }
        );
    }
}