using MedPoint.DAL.Data;
using MedPoint.DAL.Entities;
using MedPoint.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedPoint.DAL.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext context) 
            : base(context) 
        { 

        }

        public async Task<IEnumerable<Doctor>> GetBySpecializationAsync(string specialization)
        {
            return await _dbSet
                .Where(d => d.Specialization == specialization)
                .ToListAsync();
        }

        public async Task<Doctor?> GetWithAppointmentsAsync(int id)
        {
            return await _dbSet
                .Include(d => d.Appointments)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
