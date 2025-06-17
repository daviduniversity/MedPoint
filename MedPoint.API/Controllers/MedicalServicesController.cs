using MedPoint.BLL.DTO;
using MedPoint.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalServicesController : ControllerBase
    {
        private readonly IMedicalServiceService _medicalServiceService;

        public MedicalServicesController(IMedicalServiceService medicalServiceService)
        {
            _medicalServiceService = medicalServiceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalServiceDto>>> GetAll()
        {
            var services = await _medicalServiceService.GetAllAsync();
            return Ok(services);
        }

        [HttpGet("price-range")]
        public async Task<ActionResult<IEnumerable<MedicalServiceDto>>> GetByPriceRange([FromQuery] decimal min, [FromQuery] decimal max)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var services = await _medicalServiceService.GetByPriceRangeAsync(min, max);
            return Ok(services);
        }

        [HttpGet("{id}/details")]
        public async Task<ActionResult<MedicalServiceDetailsDto>> GetWithAppointments(int id)
        {
            var service = await _medicalServiceService.GetWithAppointmentsAsync(id);
            if (service == null)
                return NotFound();

            return Ok(service);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateMedicalServiceDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _medicalServiceService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetWithAppointments), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMedicalServiceDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _medicalServiceService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _medicalServiceService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
