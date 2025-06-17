using MedPoint.BLL.DTO;
using MedPoint.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentServicesController : ControllerBase
    {
        private readonly IAppointmentServiceService _appointmentServiceService;

        public AppointmentServicesController(IAppointmentServiceService appointmentServiceService)
        {
            _appointmentServiceService = appointmentServiceService;
        }

        [HttpGet("{appointmentId}")]
        public async Task<ActionResult<IEnumerable<AppointmentServiceResponseDto>>> GetByAppointmentId(int appointmentId)
        {
            var services = await _appointmentServiceService.GetByAppointmentIdAsync(appointmentId);
            return Ok(services);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] int appointmentId, [FromQuery] int medicalServiceId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _appointmentServiceService.CreateAsync(appointmentId, medicalServiceId);
            return CreatedAtAction(nameof(GetByAppointmentId), new { appointmentId }, null);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int appointmentId, [FromQuery] int medicalServiceId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _appointmentServiceService.DeleteAsync(appointmentId, medicalServiceId);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
