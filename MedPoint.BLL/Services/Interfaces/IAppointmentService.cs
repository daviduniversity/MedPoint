using MedPoint.BLL.DTO;

namespace MedPoint.BLL.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<AppointmentDto?> GetByIdAsync(int id);
        Task<IEnumerable<AppointmentDto>> GetByDoctorIdAsync(int doctorId);
        Task<IEnumerable<AppointmentDto>> GetByPatientIdAsync(int patientId);
        Task<int> CreateAsync(CreateAppointmentDto dto);
        Task<bool> UpdateAsync(int id, UpdateAppointmentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
