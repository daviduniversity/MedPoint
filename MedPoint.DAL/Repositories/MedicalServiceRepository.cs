using MedPoint.DAL.Data;
using MedPoint.DAL.Entities;
using MedPoint.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedPoint.DAL.Repositories
{
    public class MedicalServiceRepository : GenericRepository<MedicalService>, IMedicalServiceRepository
    {
        public MedicalServiceRepository(ApplicationDbContext context) 
            : base(context) 
        {

        }
        public async Task<IEnumerable<MedicalService>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _dbSet
                .Where(ms => ms.Price >= minPrice && ms.Price <= maxPrice)
                .ToListAsync();
        }

        public async Task<MedicalService?> GetWithAppointmentsAsync(int id)
        {
            return await _dbSet
                .Include(ms => ms.AppointmentServices)
                    .ThenInclude(asv => asv.Appointment)
                .FirstOrDefaultAsync(ms => ms.Id == id);
        }
    }
}
