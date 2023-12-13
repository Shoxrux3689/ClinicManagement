using AutoMapper;
using Clinic.Domain.Dto_s;
using Clinic.Domain.Entities;
using Clinic.Services.Exceptions;
using Clinic.Services.Repositories.Generic;
using Clinic.ViewModel.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services.Repositories.TreatmentRepositories;

public class TreatmentRepository : ITreatmentRepository
{
    private readonly IGenericRepository<Treatment> _treatmentRepository;
    private readonly IGenericRepository<Organization> _organizationRepository;
   
    private readonly IMapper _mapper;

    public TreatmentRepository(IGenericRepository<Treatment> treatmentRepository, IMapper mapper, IGenericRepository<Organization> organizationRepository)
    {
        _treatmentRepository = treatmentRepository;
        _mapper = mapper;
        _organizationRepository = organizationRepository;
    }

    public async Task<TreatmentModel> AddTreatmentAsync(TreatmentDto treatmentDto)
    {
        var organization = await _organizationRepository.SelectFirstAsync(c => c.Id == treatmentDto.OrganizationId);
        if (organization == null)
        {
            throw new OrganizationIsNotExistsException(treatmentDto.OrganizationId);
        }
        var treatment = _mapper.Map<Treatment>(treatmentDto);
        await _treatmentRepository.InsertAsync(treatment);
        return _mapper.Map<TreatmentModel>(treatment);
    }

    public async Task<TreatmentModel> GetTreatmentByIdAsync(int id)
    {
        var treatment= await _treatmentRepository.SelectFirstAsync
            (i => i.Id == id);
        if (treatment == null)
        {
            throw new TreatmentNotFoundException(id);
        }
        return _mapper.Map<TreatmentModel>(treatment);
    }

    public async Task<IEnumerable<TreatmentModel>> GetTreatmentsAsync()
    {
        var treatments  = await _treatmentRepository.SelectAll().ToListAsync();
        return _mapper.Map<IEnumerable<TreatmentModel>>(treatments);
    }
    
    public Task<TreatmentModel> UpdateTreatmentAsync(TreatmentDto treatmentDto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteTreatmentAsync(int id)
    {
        var treatment =await _treatmentRepository.SelectFirstAsync(i => i.Id == id);
        if (treatment == null)
        {
            throw new TreatmentNotFoundException(id);
        }
        await _treatmentRepository.DeleteAsync(treatment);
    }
}