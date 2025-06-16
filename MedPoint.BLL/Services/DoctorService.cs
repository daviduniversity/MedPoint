using MedPoint.BLL.DTO;
using MedPoint.BLL.Services.Interfaces;
using MedPoint.DAL.Entities;
using MedPoint.DAL.Repositories.Interfaces;

namespace MedPoint.BLL.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllAsync()
        {
            var doctors = await _unitOfWork.Doctors.GetAllAsync();
            return doctors.Select(MapToDto);
        }

        public async Task<IEnumerable<DoctorDto>> GetBySpecializationAsync(string specialization)
        {
            var doctors = await _unitOfWork.Doctors.GetBySpecializationAsync(specialization);
            return doctors.Select(MapToDto);
        }

        public async Task<DoctorDetailsDto?> GetWithAppointmentsAsync(int id)
        {
            var doctor = await _unitOfWork.Doctors.GetWithAppointmentsAsync(id);
            if (doctor == null) return null;

            return new DoctorDetailsDto
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
                Specialization = doctor.Specialization,
                Phone = doctor.Phone,
                Appointments = doctor.Appointments.Select(a => new AppointmentShortDto
                {
                    Id = a.Id,
                    AppointmentDate = a.AppointmentDate,
                    PatientName = a.Patient.FullName
                }).ToList()
            };
        }

        public async Task<int> CreateAsync(CreateDoctorDto dto)
        {
            var doctor = new Doctor
            {
                FullName = dto.FullName,
                Specialization = dto.Specialization,
                Phone = dto.Phone
            };

            await _unitOfWork.Doctors.AddAsync(doctor);
            await _unitOfWork.SaveChangesAsync();

            return doctor.Id;
        }

        public async Task<bool> UpdateAsync(int id, UpdateDoctorDto dto)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(id);
            if (doctor == null)
                return false;

            doctor.FullName = dto.FullName;
            doctor.Specialization = dto.Specialization;
            doctor.Phone = dto.Phone;

            _unitOfWork.Doctors.Update(doctor);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(id);
            if (doctor == null)
                return false;

            _unitOfWork.Doctors.Delete(doctor);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        private static DoctorDto MapToDto(Doctor doctor)
        {
            return new DoctorDto
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
                Specialization = doctor.Specialization,
                Phone = doctor.Phone
            };
        }
    }
}
