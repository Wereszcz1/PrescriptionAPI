using PrescriptionAPI.DTOs;
using PrescriptionAPI.Models;

namespace PrescriptionAPI.Services
{
    public interface IRepo
    {
        Task<Patient?> GetPatientById(int id);
        
        Task<Patient> AddPatient(Patient patient);
        
        Task<Prescription> AddPrescription(Prescription prescription);
        
        Task AddPrescriptionMedicaments(IEnumerable<PrescriptionMedicament> prescriptionMedicaments);
        
        Task<List<PatientResponse>> GetPatientInfo(int idPatient);
    }
}