using AutoMapper;
using Clinic.Domain.Dto_s;
using Clinic.Domain.Entities;
using Clinic.Services.Exceptions;
using Clinic.Services.Filters;
using Clinic.Services.Repositories.Generic;
using Clinic.ViewModel.Models;

namespace Clinic.Services.Repositories.PatientRepositories;

public class PatientRepository : IPatientRepository
{
    private readonly IGenericRepository<Patient> _genericRepository;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Organization> _organizationRepository;
    public PatientRepository(IGenericRepository<Patient> genericRepository, IGenericRepository<Organization> organizationRepository, IMapper mapper)
    {
        _genericRepository = genericRepository;
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }
    
    public async ValueTask<PatientModel> AddPatient(int organizationId, PatientDto patientDto)
    {
        var isOrganizationExist = await _organizationRepository.HasAnyAsync(c => c.Id == organizationId);
        if (!isOrganizationExist)
        {
            throw new OrganizationIsNotExistsException(organizationId);
        }

        var patient = _mapper.Map<Patient>(patientDto);
        patient.CreatedDate = DateTime.Now;
        patient.OrganizationId = organizationId;
        await _genericRepository.InsertAsync(patient);
        return _mapper.Map<PatientModel>(patient);
    }

    public ValueTask<IEnumerable<PatientModel>> GetPatients(PatientFilter filter)
    {
        throw new NotImplementedException();
    }

    public ValueTask<PatientModel> GetPatientById(int patientId)
    {
        throw new NotImplementedException();
    }

    public void DeletePatient(int patientId)
    {
        throw new NotImplementedException();
    }
}