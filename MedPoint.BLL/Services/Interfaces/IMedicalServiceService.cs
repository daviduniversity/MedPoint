using MedPoint.BLL.DTO;

namespace MedPoint.BLL.Services.Interfaces
{
    public interface IMedicalServiceService
    {
        Task<IEnumerable<MedicalServiceDto>> GetAllAsync();
        Task<IEnumerable<MedicalServiceDto>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<MedicalServiceDetailsDto?> GetWithAppointmentsAsync(int id);
        Task<int> CreateAsync(CreateMedicalServiceDto dto);
        Task<bool> UpdateAsync(int id, UpdateMedicalServiceDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
