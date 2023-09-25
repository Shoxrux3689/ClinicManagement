using ClinicManagement.Context;
using ClinicManagement.Entities;
using ClinicManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly AppDbContext _context;

    public DoctorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateDoctor(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();
        return doctor.Id;
    }

    public async Task<Doctor?> GetDoctorById(int doctorId)
    {
        var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == doctorId);
        return doctor;
    }

    public async Task UpdateDoctor(Doctor doctor)
    {
        _context.Update(doctor);
        await _context.SaveChangesAsync();
    }
}
