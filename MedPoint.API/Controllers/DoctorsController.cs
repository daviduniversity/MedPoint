using MedPoint.BLL.DTO;
using MedPoint.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetAll()
        {
            var doctors = await _doctorService.GetAllAsync();
            return Ok(doctors);
        }

        [HttpGet("specialization/{specialization}")]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetBySpecialization(string specialization)
        {
            var doctors = await _doctorService.GetBySpecializationAsync(specialization);
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDetailsDto>> GetWithAppointments(int id)
        {
            var doctor = await _doctorService.GetWithAppointmentsAsync(id);
            if (doctor == null)
                return NotFound();

            return Ok(doctor);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateDoctorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _doctorService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetWithAppointments), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDoctorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _doctorService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _doctorService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
