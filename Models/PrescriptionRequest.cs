namespace WebApplication1.Models;

public class PrescriptionRequest
{
    public Patient Patient { get; set; }
    public List<MedicamentRequest> Medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public int IdDoctor { get; set; }
}