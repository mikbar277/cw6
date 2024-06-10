using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    
    [Required]
    [MaxLength(length: 100)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(length: 100)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(length: 100)]
    public string Type { get; set; }
    
    public virtual ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}