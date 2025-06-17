using MedPoint.DAL.Data;
using MedPoint.DAL.Entities;
using MedPoint.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedPoint.DAL.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context) 
            : base(context) 
        { 

        }

        public async Task<Patient?> GetByEmailAsync(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<Patient?> GetWithAppointmentsAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Appointments)
                    .ThenInclude(a => a.Doctor)  
                .Include(p => p.Appointments)
                    .ThenInclude(a => a.AppointmentServices)
                        .ThenInclude(asv => asv.MedicalService) 
                .FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
