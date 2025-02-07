using Microsoft.EntityFrameworkCore;
using Texnokaktus.ProgOlymp.UserService.DataAccess.Entities;

namespace Texnokaktus.ProgOlymp.UserService.DataAccess.Context;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Region> Regions { get; set; }
    public DbSet<Application> Applications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Region>(builder =>
        {
            builder.HasKey(region => region.Id);
            builder.Property(region => region.Id)
                   .ValueGeneratedNever();

            builder.Property(region => region.Order)
                   .HasDefaultValue(0);

            builder.HasIndex(region => region.Name)
                   .IsUnique();
        });

        modelBuilder.Entity<Application>(builder =>
        {
            builder.HasKey(application => application.Id);

            builder.HasAlternateKey(application => new { application.ContestId, application.YandexIdLogin });

            builder.HasOne(application => application.Region)
                   .WithMany()
                   .HasForeignKey(application => application.RegionId);

            builder.OwnsOne<ThirdPerson>(application => application.Parent);
            builder.OwnsOne<Teacher>(application => application.Teacher);
        });

        base.OnModelCreating(modelBuilder);
    }
}
