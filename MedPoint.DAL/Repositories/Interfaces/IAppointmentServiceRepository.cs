using MedPoint.DAL.Entities;

namespace MedPoint.DAL.Repositories.Interfaces
{
    public interface IAppointmentServiceRepository : IGenericRepository<AppointmentService>
    {
        Task<IEnumerable<AppointmentService>> GetByAppointmentIdAsync(int appointmentId);
    }
}
