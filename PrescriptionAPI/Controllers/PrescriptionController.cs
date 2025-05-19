using Microsoft.AspNetCore.Mvc;
using PrescriptionAPI.DTOs;
using PrescriptionAPI.Services;

namespace PrescriptionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController(IDbService dbService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(PrescriptionCreateRequest request)
        {
            var result = await dbService.AddPrescription(request);
            return result.IsFailure ? BadRequest(result.Value) : Ok(result.Error);
        }
    }
}