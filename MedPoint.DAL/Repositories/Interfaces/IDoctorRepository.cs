using MedPoint.DAL.Entities;

namespace MedPoint.DAL.Repositories.Interfaces
{
    public interface IDoctorRepository : IGenericRepository<Doctor>
    {
        Task<IEnumerable<Doctor>> GetBySpecializationAsync(string specialization);
        Task<Doctor?> GetWithAppointmentsAsync(int id);
    }
}
