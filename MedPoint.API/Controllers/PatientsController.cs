using MedPoint.BLL.DTO;
using MedPoint.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetAll()
        {
            var patients = await _patientService.GetAllAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetById(int id)
        {
            var patient = await _patientService.GetByIdAsync(id);
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        [HttpGet("{id}/appointments")]
        public async Task<ActionResult<PatientDetailsDto>> GetWithAppointments(int id)
        {
            var patient = await _patientService.GetWithAppointmentsAsync(id);
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        [HttpGet("by-email")]
        public async Task<ActionResult<PatientDto>> GetByEmail([FromQuery] string email)
        {
            var patient = await _patientService.GetByEmailAsync(email);
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreatePatientDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _patientService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePatientDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _patientService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _patientService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
