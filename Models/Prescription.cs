using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public DateTime DueDate { get; set; }
    
    // Foreign key for Patient
    public int IdPatient { get; set; }
    public Patient Patient { get; set; }
    
    // Foreign key for Doctor
    public int IdDoctor { get; set; }
    public Doctor Doctor { get; set; }
    
    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}