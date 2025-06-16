using MedPoint.BLL.DTO;
using MedPoint.BLL.Services.Interfaces;
using MedPoint.DAL.Entities;
using MedPoint.DAL.Repositories.Interfaces;

namespace MedPoint.BLL.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PatientDto>> GetAllAsync()
        {
            var patients = await _unitOfWork.Patients.GetAllAsync();
            return patients.Select(MapToDto);
        }

        public async Task<PatientDto?> GetByIdAsync(int id)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);
            if (patient == null) return null;
            return MapToDto(patient);
        }

        public async Task<PatientDetailsDto?> GetWithAppointmentsAsync(int id)
        {
            var patient = await _unitOfWork.Patients.GetWithAppointmentsAsync(id);
            if (patient == null) return null;

            return new PatientDetailsDto
            {
                Id = patient.Id,
                FullName = patient.FullName,
                DateOfBirth = patient.DateOfBirth,
                ContactPhone = patient.ContactPhone,
                Email = patient.Email,
                Appointments = patient.Appointments.Select(a => new AppointmentDto
                {
                    Id = a.Id,
                    AppointmentDate = a.AppointmentDate,
                    Notes = a.Notes,
                    DoctorId = a.DoctorId,
                    DoctorName = a.Doctor.FullName,
                    PatientId = a.PatientId,
                    PatientName = a.Patient.FullName,
                    Services = a.AppointmentServices.Select(s => new AppointmentServiceDto
                    {
                        MedicalServiceId = s.MedicalServiceId,
                        ServiceName = s.MedicalService.Name
                    }).ToList()
                }).ToList()
            };
        }

        public async Task<PatientDto?> GetByEmailAsync(string email)
        {
            var patient = await _unitOfWork.Patients.GetByEmailAsync(email);
            if (patient == null) return null;
            return MapToDto(patient);
        }

        public async Task<int> CreateAsync(CreatePatientDto dto)
        {
            var entity = new Patient
            {
                FullName = dto.FullName,
                DateOfBirth = dto.DateOfBirth,
                ContactPhone = dto.ContactPhone,
                Email = dto.Email
            };

            await _unitOfWork.Patients.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(int id, UpdatePatientDto dto)
        {
            var entity = await _unitOfWork.Patients.GetByIdAsync(id);
            if (entity == null) return false;

            entity.FullName = dto.FullName;
            entity.DateOfBirth = dto.DateOfBirth;
            entity.ContactPhone = dto.ContactPhone;
            entity.Email = dto.Email;

            _unitOfWork.Patients.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.Patients.GetByIdAsync(id);
            if (entity == null) return false;

            _unitOfWork.Patients.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        private static PatientDto MapToDto(Patient entity)
        {
            return new PatientDto
            {
                Id = entity.Id,
                FullName = entity.FullName,
                DateOfBirth = entity.DateOfBirth,
                ContactPhone = entity.ContactPhone,
                Email = entity.Email
            };
        }
    }
}
