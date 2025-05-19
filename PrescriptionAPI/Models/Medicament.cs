using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrescriptionAPI.Models;
[Table("Medicament")]
public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Type { get; set; }
    
    public virtual ICollection<PrescriptionMedicament> Prescription_Medicaments { get; set; }
}