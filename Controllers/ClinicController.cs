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
    public async Task<IActionResult> CreatePrescription([FromBody] PrescriptionRequest request)
    {
        if (request.Medicaments.Count > 10)
        {
            return BadRequest("Recepta może obejmować maksymalnie 10 leków.");
        }

        if (request.DueDate < request.Date)
        {
            return BadRequest("Data wystawienia musi byc większa od daty ważności");
        }

        var patient = await _context.Patients.FindAsync(request.Patient.IdPatient);
        if (patient == null)
        {
            patient = new Patient
            {
                FirstName = request.Patient.FirstName,
                LastName = request.Patient.LastName,
                Birthdate = request.Patient.Birthdate
            };
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        var doctor = await _context.Doctors.FindAsync(request.IdDoctor);
        if (doctor == null)
        {
            return BadRequest($"Lekarz o podanym ID {request.IdDoctor} nie istnieje");
        }

        foreach (var medicamentRequest in request.Medicaments)
        {
            var medicament = await _context.Medicaments.FindAsync(medicamentRequest.IdMedicament);
            if (medicament == null)
            {
                return BadRequest($"Lek o podanym ID {medicamentRequest.IdMedicament} nie istnieje.");
            }
        }

        var prescription = new Prescription
        {
            Date = request.Date,
            DueDate = request.DueDate,
            Patient = patient,
            Doctor = doctor
        };
        
        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();
        
        foreach (var medicament in request.Medicaments)
        {
            var prescriptionMedicament = new PrescriptionMedicament
            {
                IdPrescription = prescription.IdPrescription,
                IdMedicament = medicament.IdMedicament,
                Prescription = prescription
            };
            _context.PrescriptionMedicaments.Add(prescriptionMedicament);
        }

        return Ok(prescription);
    }
}