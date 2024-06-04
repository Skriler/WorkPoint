using Microsoft.EntityFrameworkCore;
using WorkPoint.Models.Entities;
using WorkPoint.Models.Entities.Skills;

namespace WorkPoint.SL.DAL;

public class WorkPointDbContext : DbContext
{
    public DbSet<Speciality> Specialities { get; set; }
    public DbSet<SoftSkills> SoftSkills { get; set; }
    public DbSet<HardSkills> HardSkills { get; set; }
    public DbSet<ProgrammingSkills> ProgrammingSkills { get; set; }
    public DbSet<DatabaseSkills> DBSkills { get; set; }
    public DbSet<MicrosoftOfficeSkills> MSOfficeSkills { get; set; }
    public DbSet<OperatingSystemSkills> OSSkills { get; set; }
    public DbSet<GraphicEditorsSkills> GESkills { get; set; }
    public DbSet<ExtraSkills> ExtraSkills { get; set; }

    public WorkPointDbContext(DbContextOptions<WorkPointDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        DataInitializer.Initialize();

        DataSeeder.SeedTable(builder, DataInitializer.ProgrammingSkills);
        DataSeeder.SeedTable(builder, DataInitializer.DBSkills);
        DataSeeder.SeedTable(builder, DataInitializer.MSOfficeSkills);
        DataSeeder.SeedTable(builder, DataInitializer.OSSkills);
        DataSeeder.SeedTable(builder, DataInitializer.GESkills);
        DataSeeder.SeedTable(builder, DataInitializer.ExtraSkills);
        DataSeeder.SeedTable(builder, DataInitializer.SoftSkills);
    }

}
