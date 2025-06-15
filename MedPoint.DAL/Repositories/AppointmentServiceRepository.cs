using MedPoint.DAL.Data;
using MedPoint.DAL.Entities;
using MedPoint.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedPoint.DAL.Repositories
{
    public class AppointmentServiceRepository : GenericRepository<AppointmentService>, IAppointmentServiceRepository
    {
        public AppointmentServiceRepository(ApplicationDbContext context) 
            : base(context) 
        {

        }

        public async Task<IEnumerable<AppointmentService>> GetByAppointmentIdAsync(int appointmentId)
        {
            return await _dbSet
                .Where(x => x.AppointmentId == appointmentId)
                .Include(x => x.Appointment)
                .Include(x => x.MedicalService)
                .ToListAsync();
        }
    }
}
