using Clinic.Domain.Dto_s;
using Clinic.Services.Exceptions;
using Clinic.Services.Repositories.TreatmentRepositories;
using Clinic.Services.Repositories.VisitRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class VisitsController : ControllerBase
{
    private readonly IVisitRepository _visitRepository;

    public VisitsController(IVisitRepository visitRepository)
    {
        _visitRepository = visitRepository;
    }

    [HttpPost]
    public async ValueTask<IActionResult> AddVisit([FromForm]VisitDto visitDto)
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

    [HttpPut]
    public async ValueTask<IActionResult> UpdateVisit([FromForm]UpdateVisitDto visitDto)
    {
        try
        {
            var visit = await _visitRepository.UpdateVisit(visitDto);
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
        catch (TreatmentNotFoundException e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("visitsPatientId/{patientId}")]
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

    [HttpGet("{visitId}")]
    public async ValueTask<IActionResult> GetVisitById(int visitId)
    {
        try
        {
            var visit = await _visitRepository.GetVisitById(visitId);
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

    [HttpDelete("{visitId}")]
    public async ValueTask<IActionResult> DeleteVisit(int visitId)
    {
        try
        {
            await _visitRepository.DeleteVisit( visitId);
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