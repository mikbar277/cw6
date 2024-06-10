using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    
    [Required]
    [MaxLength(length: 100)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(length: 100)]
    public string LastName { get; set; }
    
    [Required]
    public DateTime Birthdate { get; set; }
    
    public ICollection<Prescription> Prescriptions { get; set; }
}