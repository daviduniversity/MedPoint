using MedPoint.DAL.Data;
using MedPoint.DAL.Repositories.Interfaces;

namespace MedPoint.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IDoctorRepository Doctors { get; }
        public IPatientRepository Patients { get; }
        public IMedicalServiceRepository MedicalServices { get; }
        public IAppointmentRepository Appointments { get; }
        public IAppointmentServiceRepository AppointmentServices { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Doctors = new DoctorRepository(_context);
            Patients = new PatientRepository(_context);
            MedicalServices = new MedicalServiceRepository(_context);
            Appointments = new AppointmentRepository(_context);
            AppointmentServices = new AppointmentServiceRepository(_context);
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
