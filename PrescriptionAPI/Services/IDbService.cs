using PrescriptionAPI.DTOs;
using PrescriptionAPI.Helpers;

namespace PrescriptionAPI.Services;

public interface IDbService
{
    Task<Result<List<PatientResponse>>> GetPatientInfo(int IdPatient);
    Task<Result<int>> AddPrescription(PrescriptionCreateRequest request);
}