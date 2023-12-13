using Clinic.Domain.Dto_s;
using Clinic.Services.Exceptions;
using Clinic.Services.Repositories.TreatmentRepositories;
using Clinic.Services.Repositories.VisitRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VisitsController : ControllerBase
{
    private readonly IVisitRepository _visitRepository;

    public VisitsController(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }

    [HttpPost]
    public async ValueTask<IActionResult> AddVisit(VisitDto visitDto)
    {
        try
        {
            var visit = await _visitRepository.AddVisit(visitDto);
            return Ok(visit);
        }
        catch (TreatmentNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        
        catch (PatientNotFoundException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{patientId}")]
    public async ValueTask<IActionResult> GetVisitsByPatientId(int patientId)
    {
        try
        {
            var visits = await _visitRepository.GetVisitsByPatientId(patientId);
            return Ok(visits);
        }
        catch (PatientNotFoundException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetVisits()
    {
        try
        {
            var visits = await _visitRepository.GetVisits();
            return Ok(visits);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("/patients/{patientId}/visits/{visitId}")]
    public async ValueTask<IActionResult> GetVisitById(int patientId, int visitId)
    {
        try
        {
            var visit = await _visitRepository.GetVisitById(patientId, visitId);
            return Ok(visit);
        }
        catch (PatientNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (VisitNotFoundException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("/patients/{patientId}/visits/{visitId}")]
    public async ValueTask<IActionResult> DeleteVisit(int patientId, int visitId)
    {
        try
        {
            await _visitRepository.DeleteVisit(patientId, visitId);
            return Ok();
        }
        catch (PatientNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (VisitNotFoundException e)
        {
            return BadRequest(e.Message);
        }
    }
}