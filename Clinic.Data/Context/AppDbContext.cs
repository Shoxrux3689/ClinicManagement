using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data.Context;

public class AppDbContext : DbContext
{
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Treatment> Treatments { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<VisitTreatment> VisitTreatments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VisitTreatment>().HasKey(c => c.Id);
        modelBuilder.Entity<Patient>().HasKey(c => c.Id);
        modelBuilder.Entity<Patient>().HasMany(c => c.Visits).WithOne(c => c.Patient);
        modelBuilder.Entity<VisitTreatment>()
            .HasOne(vt => vt.Visit)
            .WithMany(v => v.VisitsTreatments)
            .HasForeignKey(vt => vt.VisitId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}