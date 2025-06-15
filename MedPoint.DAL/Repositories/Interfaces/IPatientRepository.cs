using MedPoint.DAL.Entities;

namespace MedPoint.DAL.Repositories.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        Task<Patient?> GetByEmailAsync(string email);
        Task<Patient?> GetWithAppointmentsAsync(int id);
    }
}
