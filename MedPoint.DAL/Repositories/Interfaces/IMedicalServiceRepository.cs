using MedPoint.DAL.Entities;

namespace MedPoint.DAL.Repositories.Interfaces
{
    public interface IMedicalServiceRepository : IGenericRepository<MedicalService>
    {
        Task<IEnumerable<MedicalService>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<MedicalService?> GetWithAppointmentsAsync(int id);
    }
}
