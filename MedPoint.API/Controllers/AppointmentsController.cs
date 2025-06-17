using MedPoint.BLL.DTO;
using MedPoint.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDto>> GetById(int id)
        {
            var appointment = await _appointmentService.GetByIdAsync(id);
            if (appointment == null)
                return NotFound();

            return Ok(appointment);
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetByDoctorId(int doctorId)
        {
            var appointments = await _appointmentService.GetByDoctorIdAsync(doctorId);
            return Ok(appointments);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetByPatientId(int patientId)
        {
            var appointments = await _appointmentService.GetByPatientIdAsync(patientId);
            return Ok(appointments);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateAppointmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _appointmentService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAppointmentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _appointmentService.UpdateAsync(id, dto);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _appointmentService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
