using MedPoint.DAL.Data;
using MedPoint.DAL.Entities;
using MedPoint.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedPoint.DAL.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context) 
            : base(context) 
        { 

        }

        public async Task<Appointment?> GetWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.AppointmentServices)
                    .ThenInclude(asv => asv.MedicalService)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Appointment>> GetByDoctorIdAsync(int doctorId)
        {
            return await _dbSet
                .Where(a => a.DoctorId == doctorId)
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByPatientIdAsync(int patientId)
        {
            return await _dbSet
                .Where(a => a.PatientId == patientId)
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .ToListAsync();
        }
    }
}
