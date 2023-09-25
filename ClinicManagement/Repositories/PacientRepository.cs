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

    public async Task CreatePacient(Pacient pacient)
    {
        _context.Pacients.Add(pacient);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePacient(Pacient pacient)
    {
        _context.Pacients.Remove(pacient);
        await _context.SaveChangesAsync();
    }

    public async Task<Pacient?> GetPacientById(int pacientId)
    {
        var pacient = await _context.Pacients.FirstOrDefaultAsync(p => p.Id == pacientId);
        
        return pacient;
    }

    public async Task<List<Pacient>?> GetPacientsByFilter(PacientFilter pacientFilter)
    {
        //chala qilindi
        var pacients = await _context.Pacients.ToListAsync();
        return pacients;
    }

    public async Task UpdatePacient(Pacient pacient)
    {
        _context.Update(pacient);
        await _context.SaveChangesAsync();
    }
}
