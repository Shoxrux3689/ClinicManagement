using Clinic.Domain.Dto_s;
using Clinic.Services.Exceptions;
using Clinic.Services.Filters;
using Clinic.Services.Repositories.PatientRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
namespace Clinic.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PatientsController : ControllerBase
{
    private readonly IPatientRepository _patientRepository;

    public PatientsController(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    [HttpPost]
    public async ValueTask<IActionResult> AddPatient(PatientDto patientDto)
    {
        
        Log.Error("LoginOrganization");
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

    [HttpGet]
    public async ValueTask<IActionResult> GetPatients([FromQuery] PatientFilter filter)
    {
        var patients = await _patientRepository.GetPatients(filter);
        return Ok(patients);
    }

    
    [HttpPut]
    public async ValueTask<IActionResult> UpdatePatient([FromForm]UpdatePatientInfoDto patientDto)
    {
        try
        {
            var patient = await _patientRepository.UpdatePatient(patientDto);
            return Ok(patient);
        }
        catch (PatientNotFoundException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("{patientId}")]
    public async ValueTask<IActionResult> GetPatientById(int patientId)
    {
        try
        {
            var patient = await _patientRepository.GetPatientById( patientId);
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

    [HttpDelete("{patientId}")]
    public async ValueTask<IActionResult> DeletePatient(int patientId)
    {
        try
        {
            await _patientRepository.DeletePatient(patientId);
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