using AutoMapper;
using Clinic.Data.Context;
using Clinic.Domain.Dto_s;
using Clinic.Domain.Entities;
using Clinic.Services.Exceptions;
using Clinic.Services.Repositories.Generic;
using Clinic.Services.Repositories.TreatmentRepositories;
using Clinic.ViewModel.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services.Repositories.VisitRepositories;

public class VisitRepository : IVisitRepository
{
    private readonly IGenericRepository<Visit> _visitRepository;
    private readonly IGenericRepository<Patient> _patientRepository;
    private readonly IGenericRepository<Treatment> _treatmentRepository;
    private readonly IGenericRepository<VisitTreatment> _visitTreatmentRepository;
    private readonly IMapper _mapper;

    public VisitRepository(IGenericRepository<Visit> visitRepository, IGenericRepository<Patient> patientRepository,
        IMapper mapper, IGenericRepository<Treatment> treatmentRepository,
        IGenericRepository<VisitTreatment> visitTreatmentRepository)
    {
        _visitRepository = visitRepository;
        _patientRepository = patientRepository;
        _mapper = mapper;
        _treatmentRepository = treatmentRepository;
        _visitTreatmentRepository = visitTreatmentRepository;
    }

    public async ValueTask<VisitModel> AddVisit(VisitDto visitDto)
    {
        var patient = await _patientRepository.SelectFirstAsync
            (c => c.Id == visitDto.PatientId);
        if (patient == null)
        {
            throw new PatientNotFoundException(visitDto.PatientId);
        }

        /*if (visitDto.TreatmentId is not null)
        {
            var treatment = await _treatmentRepository.SelectFirstAsync
                (c => c.Id == visitDto.TreatmentId);
            if (treatment == null)
            {
                throw new TreatmentNotFoundException(visitDto.TreatmentId.Value);
            }

            var visit = _mapper.Map<Visit>(visitDto);
            visit.VisitDate = DateTime.Now;
            var result = await _visitRepository.InsertAsync(visit);
            var visitTreatment = new VisitTreatment
            {
                VisitId = result.Id,
                TreatmentId = treatment.Id,
                Date = DateTime.Now
            };
            await _visitTreatmentRepository.InsertAsync(visitTreatment);
            return _mapper.Map<VisitModel>(visit);
        }*/
       
            var visit = _mapper.Map<Visit>(visitDto);
            visit.VisitDate = DateTime.Now;
            await _visitRepository.InsertAsync(visit);
            return _mapper.Map<VisitModel>(visit);
    }

    public async ValueTask<VisitModel> UpdateVisit(UpdateVisitDto visitDto)
    {
        var patient = await _patientRepository.SelectFirstAsync(c => c.Id == visitDto.PatientId);
        if (patient is null)
        {
            throw new PatientNotFoundException(visitDto.PatientId);
        }

        var visit = await _visitRepository.SelectFirstAsync(c => c.Id == visitDto.VisitId);
        if (visit is null)
        {
            throw new VisitNotFoundException(visitDto.VisitId);
        }

        if (visitDto.TreatmentId is not null)
        {
            var treatment = await _treatmentRepository.SelectFirstAsync(c => c.Id == visitDto.TreatmentId);
            if (treatment is null)
            {
                throw new TreatmentNotFoundException(visitDto.TreatmentId.Value);
            }

            var visitTreatment = new VisitTreatment()
            {
                TreatmentId = visitDto.TreatmentId.Value,
                VisitId = visitDto.VisitId,
                Date = DateTime.Now
            };
            await _visitTreatmentRepository.InsertAsync(visitTreatment);
        }
        if(visitDto.Complains is null)
        {
            visitDto.Complains = visit.Complains;
        }
        if(visitDto.Diagnosis is null)
        {
            visitDto.Diagnosis = visit.Diagnosis;
        }
        if (visitDto.Cost is null)
        {
            visitDto.Cost = visit.Cost;
        }

        if (visitDto.Prescription is null)
        {
            visitDto.Prescription = visit.Prescription;
        }
        _mapper.Map(visitDto, visit); 
        await _visitRepository.UpdateAsync(visit);
        return _mapper.Map<VisitModel>(visit);
    }


    public async ValueTask<IEnumerable<VisitModel>> GetVisitsByPatientId(int patientId)
    {
        var patient = await _patientRepository.SelectFirstAsync(c => c.Id == patientId);
        if (patient == null)
        {
            throw new PatientNotFoundException(patientId);
        }

        var visits = patient.Visits!.ToList();
        if (visits.Select(c => c.VisitsTreatments).ToList() is not null)
        {
            visits.Select(c => c.VisitsTreatments!.Select(c => _mapper.Map<VisitTreatmentModel>(c.Treatment)));
        }

        return _mapper.Map<IEnumerable<VisitModel>>(visits);
    }

    public async ValueTask<IEnumerable<VisitModel>> GetVisits()
    {
        var visits = await _visitRepository.SelectAll().ToListAsync();
        if (visits.Select(c => c.VisitsTreatments).ToList() is not null)
        {
            visits.Select(c => c.VisitsTreatments!.Select(c => _mapper.Map<VisitTreatmentModel>(c.Treatment)));
        }

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

        if (visit.VisitsTreatments.ToList() is not null)
        {
            visit.VisitsTreatments.Select(c => _mapper.Map<VisitTreatmentModel>(c.Treatment));
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