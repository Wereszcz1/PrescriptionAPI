using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrescriptionAPI.Models;
[Table("Patient")]
public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [Required]
    public DateTime Birthdate { get; set; }
    
    public virtual ICollection<Prescription> Prescriptions { get; set; }
}