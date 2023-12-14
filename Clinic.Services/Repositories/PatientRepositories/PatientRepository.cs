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
using Microsoft.AspNetCore.Mvc;

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

    public async ValueTask<PatientModel> AddPatient(PatientDto patientDto)
    {
        var isOrganizationExist = await _organizationRepository.HasAnyAsync(c => c.Id == patientDto.OrganizationId);
        if (!isOrganizationExist)
        {
            throw new OrganizationIsNotExistsException(patientDto.OrganizationId);
        }

        var patient = _mapper.Map<Patient>(patientDto);
        patient.CreatedDate = DateTime.Now;
        await _genericRepository.InsertAsync(patient);
        return _mapper.Map<PatientModel>(patient);
    }

    public async ValueTask<PatientModel> UpdatePatient(UpdatePatientInfoDto patientDto)
    {
        var patient = await _genericRepository.
            SelectFirstAsync(c => c.Id == patientDto.Id);
        if (patient is null)
        {
            throw new PatientNotFoundException(patientDto.Id);
        }
        if (patientDto.FirstName is null)
        {
            patientDto.FirstName = patient.FirstName;
        }

        if (patientDto.PhoneNumber is null)
        {
            patientDto.PhoneNumber = patient.PhoneNumber;
        }

        if (patientDto.LastName is null)
        {
            patientDto.PhoneNumber = patient.PhoneNumber;
        }   
        if (patientDto.Gender is null)
        {
            patientDto.Gender = patient.Gender;
        }

        if (patientDto.DateOfBirth is null)
        {
            patientDto.DateOfBirth = patient.DateOfBirth;
        }
        _mapper.Map(patientDto,patient);
        await _genericRepository.UpdateAsync(patient);
        return _mapper.Map<PatientModel>(patient);
    }

    public async ValueTask<IEnumerable<PatientModel>?> GetPatients(PatientFilter filter)
    {
        var patients = _genericRepository.SelectAll();
        if (filter.FirstName is not null)
        {
            patients = patients.Where(t => t.FirstName!.ToLower()
                .Contains(filter.FirstName.ToLower()));
        }

        if (filter.OrganizationId is not null)
        {
            patients = patients.Where(t => t.OrganizationId == filter.OrganizationId);
        }

        if (filter.LastName is not null)
        {
            patients = patients.Where(t => t.LastName!.ToLower()
                .Contains(filter.LastName.ToLower()));
        }

        if (filter.PhoneNumber is not null)
        {
            patients = patients.Where(t => t.PhoneNumber!.ToLower()
                .Contains(filter.PhoneNumber.ToLower()));
        }

        if (filter.Gender is not null)
        {
            patients = patients.Where(t => t.PhoneNumber == filter.PhoneNumber);
        }

        if (filter.CreatedDate is not null)
        {
            patients = patients.Where(t => t.CreatedDate == filter.CreatedDate);
        }
        var patientsPages = await patients.ToPagedListAsync(_httpContextHelper, filter);
        return patientsPages.Select(v => _mapper.Map<PatientModel>(v));
    }

    public async ValueTask<PatientModel?> GetPatientById(int organizationId, int patientId)
    {
        var organization = await _organizationRepository.SelectFirstAsync(c => c.Id == organizationId);
        if (organization is null)
        {
            throw new OrganizationIsNotExistsException(organizationId);
        }

        var patient = organization.Patients!.FirstOrDefault(i => i.Id == patientId);
        if (patient is null)
        {
            throw new PatientNotFoundException(patientId);
        }

        return _mapper.Map<PatientModel>(patient);
    }

    public async ValueTask DeletePatient(int organizationId, int patientId)
    {
        var organization = await _organizationRepository.SelectFirstAsync(t => t.Id == organizationId);
        if (organization is null)
        {
            throw new OrganizationIsNotExistsException(organizationId);
        }

        // null ni ichidan qanday qidiradi, topolmidiyu hech nimani
        var patient = organization.Patients!.FirstOrDefault(i => i.Id == patientId);
        if (patient is null)
        {
            throw new PatientNotFoundException(patientId);
        }

        await _genericRepository.DeleteAsync(patient);
    }
}