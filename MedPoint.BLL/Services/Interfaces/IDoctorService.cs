using MedPoint.BLL.DTO;

namespace MedPoint.BLL.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetAllAsync();
        Task<IEnumerable<DoctorDto>> GetBySpecializationAsync(string specialization);
        Task<DoctorDetailsDto?> GetWithAppointmentsAsync(int id);
        Task<int> CreateAsync(CreateDoctorDto dto);
        Task<bool> UpdateAsync(int id, UpdateDoctorDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
