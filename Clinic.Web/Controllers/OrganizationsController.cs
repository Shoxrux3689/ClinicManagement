using Clinic.Domain.Dto_s;
using Clinic.Services.Exceptions;
using Clinic.Services.Repositories.OrganizationRepository;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrganizationsController : ControllerBase
{
    private readonly IOrganizationRepository _organizationRepository;

    public OrganizationsController(IOrganizationRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }
    [HttpPost]
    public async ValueTask<IActionResult> RegisterOrganization(OrganizationDto organizationDto)
    {
        try
        {
            var organization = await _organizationRepository.RegisterOrganization(organizationDto);
            return Ok(organization);
        }
        catch (LoginIsAlreadyExistException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet]
    public async ValueTask<IActionResult> GetOrganizations()
    {
        try
        {
            var organizations = await _organizationRepository.GetOrganizations();
            return Ok(organizations);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet("{organizationId}")]
    public async ValueTask<IActionResult> GetOrganizationById(int organizationId)
    {
        try
        {
            var organization = await _organizationRepository.GetOrganizationById(organizationId);
            return Ok(organization);
        }
        catch (OrganizationNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpDelete("{organizationId}")]
    public async ValueTask<IActionResult> DeleteOrganization(int organizationId)
    {
        try
        {
            await _organizationRepository.DeleteOrganization(organizationId);
            return Ok();
        }
        catch (OrganizationNotFoundException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}