using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Entities;

public class Doctor
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public List<Pacient>? Pacients { get; set; }
    public List<Procedure>? Procedures { get; set; }
}
