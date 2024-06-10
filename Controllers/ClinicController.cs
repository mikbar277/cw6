using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;

namespace cw6.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClinicController : ControllerBase
{
    private readonly ClinicContext _context;

    public ClinicController(ClinicContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePrescription([FromBody] Prescription prescription)
    {
        return Ok();
    }
}