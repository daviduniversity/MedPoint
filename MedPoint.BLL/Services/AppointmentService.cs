using MedPoint.BLL.DTO;
using MedPoint.BLL.Services.Interfaces;
using MedPoint.DAL.Entities;
using MedPoint.DAL.Repositories.Interfaces;

namespace MedPoint.BLL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AppointmentDto?> GetByIdAsync(int id)
        {
            var appointment = await _unitOfWork.Appointments.GetWithDetailsAsync(id);
            if (appointment == null) return null;

            return MapToDto(appointment);
        }

        public async Task<IEnumerable<AppointmentDto>> GetByDoctorIdAsync(int doctorId)
        {
            var appointments = await _unitOfWork.Appointments.GetByDoctorIdAsync(doctorId);
            return appointments.Select(MapToDto);
        }

        public async Task<IEnumerable<AppointmentDto>> GetByPatientIdAsync(int patientId)
        {
            var appointments = await _unitOfWork.Appointments.GetByPatientIdAsync(patientId);
            return appointments.Select(MapToDto);
        }

        public async Task<int> CreateAsync(CreateAppointmentDto dto)
        {
            var appointment = new Appointment
            {
                AppointmentDate = dto.AppointmentDate,
                Notes = dto.Notes,
                DoctorId = dto.DoctorId,
                PatientId = dto.PatientId,
                AppointmentServices = dto.MedicalServiceIds
                    .Select(id => new DAL.Entities.AppointmentService
                    {
                        MedicalServiceId = id
                    }).ToList()
            };

            await _unitOfWork.Appointments.AddAsync(appointment);
            await _unitOfWork.SaveChangesAsync();
            return appointment.Id;
        }

        public async Task<bool> UpdateAsync(int id, UpdateAppointmentDto dto)
        {
            var appointment = await _unitOfWork.Appointments.GetWithDetailsAsync(id);
            if (appointment == null) return false;

            appointment.AppointmentDate = dto.AppointmentDate;
            appointment.Notes = dto.Notes;
            appointment.DoctorId = dto.DoctorId;
            appointment.PatientId = dto.PatientId;

            appointment.AppointmentServices.Clear();

            foreach (var serviceId in dto.MedicalServiceIds)
            {
                appointment.AppointmentServices.Add(new DAL.Entities.AppointmentService
                {
                    AppointmentId = appointment.Id,
                    MedicalServiceId = serviceId
                });
            }

            _unitOfWork.Appointments.Update(appointment);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var appointment = await _unitOfWork.Appointments.GetWithDetailsAsync(id);
            if (appointment == null) return false;

            _unitOfWork.Appointments.Delete(appointment);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        private static AppointmentDto MapToDto(Appointment appointment)
        {
            return new AppointmentDto
            {
                Id = appointment.Id,
                AppointmentDate = appointment.AppointmentDate,
                Notes = appointment.Notes,
                DoctorId = appointment.DoctorId,
                DoctorName = appointment.Doctor.FullName,
                PatientId = appointment.PatientId,
                PatientName = appointment.Patient.FullName,
                Services = appointment.AppointmentServices.Select(s => new AppointmentServiceDto
                {
                    MedicalServiceId = s.MedicalServiceId,
                    ServiceName = s.MedicalService.Name
                }).ToList()
            };
        }
    }
}
