using ClinicManagement.Context;
using ClinicManagement.Entities;
using ClinicManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ClinicManagement.Repositories;

public class PacientRepository : IPacientRepository
{
    private readonly AppDbContext _context;

    public PacientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async ValueTask<bool> CreatePacient(Pacient pacient)
    {
        _context.Pacients.Add(pacient);
        await _context.SaveChangesAsync();

        return true;
    }

    public async ValueTask<bool> DeletePacient(Pacient pacient)
    {
        _context.Pacients.Update(pacient);
        await _context.SaveChangesAsync();
        return true;
    }

    public async ValueTask<Pacient?> GetPacientById(int Id)
    {
        var pacient = await _context.Pacients.FirstOrDefaultAsync(p => p.Id == Id);
        return pacient;
    }

    public async ValueTask<Pacient?> GetPacientByName(string name)
    {
        var pacient = await _context.Pacients.FirstOrDefaultAsync(p => p.Name == name);
        return pacient;
    }

    public async ValueTask<Pacient?> GetPacientByPhoneNumber(string phoneNumber)
    {
        var pacient = await _context.Pacients.FirstOrDefaultAsync(p => p.PhoneNumber == phoneNumber);
        return pacient;
    }

    public async ValueTask<List<Pacient>> GetPacients()
    {
        var pacients = await _context.Pacients.ToListAsync();
        return pacients;
    }

    public async ValueTask<bool> UpdatePacient(Pacient pacient)
    {
        _context.Pacients.Update(pacient);
        await _context.SaveChangesAsync();
        return true;
    }
}
