using AutoMapper;
using Clinic.Domain.Dto_s;
using Clinic.Domain.Entities;
using Clinic.Services.Exceptions;
using Clinic.Services.Repositories.Generic;
using Clinic.ViewModel.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services.Repositories.VisitRepositories;

public class VisitRepository : IVisitRepository
{
    private readonly IGenericRepository<Visit> _visitRepository;
    private readonly IGenericRepository<Patient> _patientRepository;
    private readonly IMapper _mapper;

    public VisitRepository(IGenericRepository<Visit> visitRepository, IGenericRepository<Patient> patientRepository,
        IMapper mapper)
    {
        _visitRepository = visitRepository;
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    public async ValueTask<VisitModel> AddVisit(VisitDto visitDto)
    {
        var patient = await _patientRepository.SelectFirstAsync
            (c => c.Id == visitDto.PatientId);
        if (patient == null)
        {
            throw new PatientNotFoundException(visitDto.PatientId);
        }
        var visit = _mapper.Map<Visit>(visitDto);
        visit.VisitDate = DateTime.Now;
        await _visitRepository.InsertAsync(visit);
        return _mapper.Map<VisitModel>(visit);
    }

    public  async ValueTask<IEnumerable<VisitModel>> GetVisitsByPatientId(int patientId)
    {
        var patient = await _patientRepository.SelectFirstAsync(c => c.Id == patientId);
        if (patient == null)
        {
            throw new PatientNotFoundException(patientId);
        }
        //null ni ichidan qanday qidiradi, topolmidiyu hech nimani
        var visits =  patient.Visits!.ToList();
        return _mapper.Map<IEnumerable<VisitModel>>(visits);
    }

    public async ValueTask<IEnumerable<VisitModel>> GetVisits()
    {
        var visits = await _visitRepository.SelectAll().ToListAsync();
        return _mapper.Map<IEnumerable<VisitModel>>(visits);
    }

    public async ValueTask<VisitModel> GetVisitById(int patientId, int visitId)
    {
        var patient = await _patientRepository.SelectFirstAsync(c => c.Id == patientId);
        if (patient == null)
        {
            throw new PatientNotFoundException(patientId);
        }
        var visit = patient.Visits!.FirstOrDefault(c => c.Id == visitId);
        if (visit is null)
        {
            throw new VisitNotFoundException(visitId);
        }
        return _mapper.Map<VisitModel>(visit);
    }

    public async ValueTask DeleteVisit(int patientId, int visitId)
    {
        var patient = await _patientRepository.SelectFirstAsync(c => c.Id == patientId);
        if (patient == null)
        {
            throw new PatientNotFoundException(patientId);
        }
        
        var visit = patient.Visits!.FirstOrDefault(c => c.Id == visitId);
        if (visit is null)
        {
            throw new VisitNotFoundException(visitId);
        }
        await _visitRepository.DeleteAsync(visit);
    }
}