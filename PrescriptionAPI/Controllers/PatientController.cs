using Microsoft.AspNetCore.Mvc;
using PrescriptionAPI.Services;

namespace PrescriptionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(IDbService dbService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int idPatient)
        {
            var result = await dbService.GetPatientInfo(idPatient);
            if (result.IsFailure)
                return BadRequest(result.Error);
            return Ok(result.Value);
        }
    }
}