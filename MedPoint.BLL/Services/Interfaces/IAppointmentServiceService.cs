using MedPoint.BLL.DTO;

namespace MedPoint.BLL.Services.Interfaces
{
    public interface IAppointmentServiceService
    {
        Task<IEnumerable<AppointmentServiceResponseDto>> GetByAppointmentIdAsync(int appointmentId);
        Task CreateAsync(int appointmentId, int medicalServiceId);
        Task<bool> DeleteAsync(int appointmentId, int medicalServiceId);
    }
}
