using Clinic.Domain.Dto_s;
using Clinic.Services.Exceptions;
using Clinic.Services.Repositories.TreatmentRepositories;
using Clinic.ViewModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Web.Controllers;

[ApiController]
[Route("api/[controller]")]

[Authorize]
public class TreatmentController : ControllerBase
{
    private readonly ITreatmentRepository _treatmentRepository;

    public TreatmentController(ITreatmentRepository treatmentRepository)
    {
        _treatmentRepository = treatmentRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TreatmentModel>>> GetTreatments()
    {
        var treatments = await _treatmentRepository.GetTreatmentsAsync();
        return Ok(treatments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TreatmentModel>> GetTreatmentById(int id)
    {
        try
        {
            var treatment = await _treatmentRepository.GetTreatmentByIdAsync(id);
            return Ok(treatment);
        }
        catch (TreatmentNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<TreatmentModel>> AddTreatment(TreatmentDto treatmentDto)
    {
        try
        {
            var treatment = await _treatmentRepository.AddTreatmentAsync(treatmentDto);
            return Ok(treatment);
        }
        catch (OrganizationIsNotExistsException e)
        {
            return BadRequest(e.Message);
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

    [HttpPut]
    public async Task<ActionResult<TreatmentModel>> UpdateTreatment(TreatmentDto treatmentDto)
    {
        var treatment = await _treatmentRepository.UpdateTreatmentAsync(treatmentDto);
        return Ok(treatment);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTreatment(int id)
    {
        try
        {
            await _treatmentRepository.DeleteTreatmentAsync(id);
            return Ok("Deleted");
        }
        catch (TreatmentNotFoundException e)
        {
            return BadRequest(e.Message);
        }
    }
    
}