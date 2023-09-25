using Admin = ClinicManagement.Entities;

namespace ClinicManagement.Entities;

public class Procedure
{
    public short Id { get; set; }
    public required string Name { get; set; }
    public Doctor? Doctor { get; set; }
    public int DoctorId { get; set; }
}
