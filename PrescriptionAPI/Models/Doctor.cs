using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrescriptionAPI.Models;

[Table("Doctor")]
public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; }
    
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [MaxLength(60)]
    public string Email { get; set; }
    
    public virtual ICollection<Prescription> Prescriptions { get; set; }
}