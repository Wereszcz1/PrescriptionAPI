﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PrescriptionAPI.Models;

[Table("Prescription")]
public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    
    public DateTime Date { get; set; }
    
    public DateTime DueDate { get; set; }
    
    [ForeignKey(nameof(Patient))]
    public int IdPatient { get; set; }
    
    public virtual Patient Patient { get; set; }
    
    [ForeignKey(nameof(Doctor))]
    public int IdDoctor { get; set; }
    
    public virtual Doctor Doctor { get; set; }
    
    public virtual ICollection<PrescriptionMedicament> Prescription_Medicaments { get; set; }
}