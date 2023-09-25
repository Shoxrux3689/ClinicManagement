using ClinicManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Context;

public class AppDbContext : DbContext
{
    public DbSet<Pacient> Pacients { get; set;}
    public DbSet<Doctor> Doctors { get; set;}
    public DbSet<Visit> Visits { get; set;}
    public DbSet<Procedure> Procedures { get; set;}
    public DbSet<VisitProcedure> VisitProcedures { get; set;}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
