using ClinicManagement.Managers;
using ClinicManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PacientsController : ControllerBase
{
    private readonly PacientManager _pacientManager;

    public PacientsController(PacientManager manager)
    {
        _pacientManager = manager;
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreatePacient([FromForm] CreatePacientModel createPacient)
    {
        var result = await _pacientManager.CreatePacient(createPacient);
        if (result == false)
            return BadRequest();

        return Ok();
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetPacients()
    {
        var pacients = await _pacientManager.GetPacients();
        return Ok(pacients);
    }

    [HttpGet("{pacientId}")]
    public async ValueTask<IActionResult> GetPacient(int pacientId)
    {
        var pacient = await _pacientManager.GetPacientById(pacientId);
        if (pacient == null)
            return NotFound();

        return Ok();
    }

    [HttpGet("find")]
    public async ValueTask<IActionResult> FindPacient(string phoneNumber)
    {
        var pacient = await _pacientManager.GetPacientByPhone(phoneNumber);
        return Ok(pacient);
    }

    [HttpPut("{pacientId}")]
    public async ValueTask<IActionResult> UpdatePacient([FromForm] UpdatePacientModel updatePacient, int pacientId)
    {
        var result = await _pacientManager.UpdatePacient(updatePacient, pacientId);
        if (result == false)
            return BadRequest();

        return Ok();
    }

    [HttpDelete("{pacientId}")]
    public async ValueTask<IActionResult> DeletePacient(int pacientId)
    {
        var result = await _pacientManager.DeletePacient(pacientId);
        if (result == false)
            return BadRequest();
        
        return Ok();
    }
}
