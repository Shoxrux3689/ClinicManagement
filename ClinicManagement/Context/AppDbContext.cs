using ClinicManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Context;

public class AppDbContext : DbContext
{
    public DbSet<Organization> Organizations { get; set;}
    public DbSet<Treatment> Treatments { get; set;}
    public DbSet<Visit> Visits { get; set;}
    public DbSet<Patient> Patients { get; set;}
    public DbSet<VisitTreatment> VisitTreatments { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
