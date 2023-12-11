using Clinic.Domain.Dto_s;
using Clinic.Services.Exceptions;
using Clinic.Services.Filters;
using Clinic.Services.Repositories.PatientRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientRepository _patientRepository;

    public PatientController(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }
    [HttpPost]
    public async ValueTask<IActionResult> AddPatient(PatientDto patientDto)
    {
        try
        {
            var patient = await _patientRepository.AddPatient(patientDto);
            return Ok(patient);
        }
        catch (OrganizationIsNotExistsException e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpPost("filter")]
    public async ValueTask<IActionResult> GetPatients([FromBody] PatientFilter filter)
    {
        var patients = await _patientRepository.GetPatients(filter);
        return Ok(patients);
    }
    [HttpGet("{organizationId}/{patient/{patientId}}")]
    public async ValueTask<IActionResult> GetPatientById(int organizationId,int patientId)
    {
        try
        {
            var patient = await _patientRepository.GetPatientById(organizationId,patientId);
            return Ok(patient);
        }
        catch (PatientNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (OrganizationIsNotExistsException e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpDelete("{organizationId}/{patient/{patientId}}")]
    public async ValueTask<IActionResult> DeletePatient(int organizationId, int patientId)
    {
        try
        {
            await _patientRepository.DeletePatient(organizationId, patientId);
            return Ok();
        }
        catch (PatientNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (OrganizationIsNotExistsException e)
        {
            return BadRequest(e.Message);
        }
    }
}