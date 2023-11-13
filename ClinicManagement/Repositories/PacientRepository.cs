using ClinicManagement.Context;
using ClinicManagement.Entities;
using ClinicManagement.Filters;
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
}
