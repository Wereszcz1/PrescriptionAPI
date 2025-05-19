using PrescriptionAPI.DTOs;
using PrescriptionAPI.Data;
using Microsoft.EntityFrameworkCore;
using PrescriptionAPI.Helpers;

namespace PrescriptionAPI.Validators;

public class PrescriptionValidator(DatabaseContext _context)
{
    public async Task<Result> ValidateAsync(PrescriptionCreateRequest request)
    {
        if (request.Medicaments is null || !request.Medicaments.Any())
            return Result
                .Failure("Prescription must include at least one medicament.");

        if (request.Medicaments.Count > 10)
            return Result
                .Failure("Prescription cannot include more than 10 medicaments.");

        if (request.DueDate < request.Date)
            return Result
                .Failure("Due date must be after or equal to the prescription date.");

        var doctorExists = await _context.Doctors
            .AnyAsync(x => x.IdDoctor == request.IdDoctor);
        if (!doctorExists)
            return Result
                .Failure($"Doctor with ID {request.IdDoctor} does not exist.");

        var requestedMedIds = request.Medicaments
            .Select(m => m.IdMedicament)
             .Distinct()
              .ToList();
        var existingMedIds = await _context.Medicaments
            .Where(m => requestedMedIds
                .Contains(m.IdMedicament))
                 .Select(m => m.IdMedicament)
                  .ToListAsync();

        var missingMedIds = requestedMedIds
            .Except(existingMedIds)
             .ToList();

        if (missingMedIds.Any())
            return Result
                .Failure($"The following medicaments do not exist: {string.Join(", ", missingMedIds)}");

        return Result.Success();
    }
}