namespace MedPoint.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDoctorRepository Doctors { get; }
        IPatientRepository Patients { get; }
        IMedicalServiceRepository MedicalServices { get; }
        IAppointmentRepository Appointments { get; }
        IAppointmentServiceRepository AppointmentServices { get; }
        Task<int> SaveChangesAsync();
    }
}
