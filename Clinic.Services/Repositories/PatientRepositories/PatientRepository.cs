using AutoMapper;
using Clinic.Domain.Dto_s;
using Clinic.Domain.Entities;
using Clinic.Services.Exceptions;
using Clinic.Services.Extensions;
using Clinic.Services.Filters;
using Clinic.Services.Pagination;
using Clinic.Services.Repositories.Generic;
using Clinic.ViewModel.Models;
using Microsoft.AspNetCore.Http;

namespace Clinic.Services.Repositories.PatientRepositories;

public class PatientRepository : IPatientRepository
{
    private readonly IGenericRepository<Patient> _genericRepository;
    private readonly IMapper _mapper;
    private readonly HttpContextHelper _httpContextHelper;
    private readonly IGenericRepository<Organization> _organizationRepository;

    public PatientRepository(IGenericRepository<Patient> genericRepository,
        IGenericRepository<Organization> organizationRepository, IMapper mapper, HttpContextHelper httpContextHelper)
    {
        _genericRepository = genericRepository;
        _organizationRepository = organizationRepository;
        _mapper = mapper;
        _httpContextHelper = httpContextHelper;
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

    public async ValueTask<IEnumerable<PatientModel>> GetPatients(PatientFilter filter)
    {
        var patients = _genericRepository.SelectAll();
        if (filter.FirstName is not null)
        {
            patients = patients.Where(t => t.FirstName.ToLower()
                .Contains(filter.FirstName.ToLower()));
        }

        if (filter.LastName is not null)
        {
            patients = patients.Where(t => t.LastName.ToLower()
                .Contains(filter.LastName.ToLower()));
        }

        if (filter.PhoneNumber is not null)
        {
            patients = patients.Where(t => t.PhoneNumber.ToLower()
                .Contains(filter.PhoneNumber.ToLower()));
        }

        if (filter.Gender is not null)
        {
            patients = patients.Where(t => t.PhoneNumber == filter.PhoneNumber);
        }
        if (filter.OrganizationId is not null)
        {
            patients = patients.Where(t => t.OrganizationId == filter.OrganizationId);
        }
        if(filter.CreatedDate is not null)
        {
            patients = patients.Where(t=>t.CreatedDate == filter.CreatedDate);
        }
        var patientsPages = patients.ToPagedListAsync(_httpContextHelper,filter).Result;
        return patientsPages.Select(v => _mapper.Map<PatientModel>(v));
    }

    public async ValueTask<PatientModel> GetPatientById(int organizationId,int patientId)
    {
        var isOrganizationExist = await _organizationRepository.HasAnyAsync(c => c.Id == organizationId);
        if (!isOrganizationExist)
        {
            throw new OrganizationIsNotExistsException(organizationId);
        }
        var patient = await _genericRepository.SelectFirstAsync(t => t.Id == patientId);
        if (patient is null)
        {
            throw new PatientNotFoundException(patientId);
        }
        return _mapper.Map<PatientModel>(patient);
    }

    public void DeletePatient(int organizationId, int patientId)
    {
        var isOrganizationExist = _organizationRepository.HasAnyAsync(c => c.Id == organizationId).Result;
        if (!isOrganizationExist)
        {
            throw new OrganizationIsNotExistsException(organizationId);
        }
        var patient = _genericRepository.SelectFirstAsync(t => t.Id == patientId).Result;
        if (patient is null)
        {
            throw new PatientNotFoundException(patientId);
        }
        _genericRepository.DeleteAsync(patient);
    }
    
}