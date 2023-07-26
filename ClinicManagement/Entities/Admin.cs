using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Entities;

public class Admin
{
    public uint Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
}
