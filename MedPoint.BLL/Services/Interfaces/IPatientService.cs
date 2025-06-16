using MedPoint.BLL.DTO;

namespace MedPoint.BLL.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDto>> GetAllAsync();
        Task<PatientDto?> GetByIdAsync(int id);
        Task<PatientDetailsDto?> GetWithAppointmentsAsync(int id);
        Task<PatientDto?> GetByEmailAsync(string email);
        Task<int> CreateAsync(CreatePatientDto dto);
        Task<bool> UpdateAsync(int id, UpdatePatientDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
