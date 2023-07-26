using ClinicManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Context;

public class AppDbContext : DbContext
{
    public DbSet<Pacient> Pacients { get; set;}
    public DbSet<Admin> Admins { get; set;}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
