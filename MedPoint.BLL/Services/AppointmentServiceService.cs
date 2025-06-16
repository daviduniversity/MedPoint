using MedPoint.BLL.DTO;
using MedPoint.BLL.Services.Interfaces;
using MedPoint.DAL.Repositories.Interfaces;

namespace MedPoint.BLL.Services
{
    public class AppointmentServiceService : IAppointmentServiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentServiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AppointmentServiceResponseDto>> GetByAppointmentIdAsync(int appointmentId)
        {
            var appointmentServices = await _unitOfWork.AppointmentServices.GetByAppointmentIdAsync(appointmentId);

            return appointmentServices.Select(x => new AppointmentServiceResponseDto
            {
                AppointmentId = x.AppointmentId,
                MedicalServiceId = x.MedicalServiceId,
                MedicalServiceName = x.MedicalService.Name,
                MedicalServicePrice = x.MedicalService.Price
            });
        }

        public async Task CreateAsync(int appointmentId, int medicalServiceId)
        {
            var entity = new DAL.Entities.AppointmentService
            {
                AppointmentId = appointmentId,
                MedicalServiceId = medicalServiceId
            };

            await _unitOfWork.AppointmentServices.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int appointmentId, int medicalServiceId)
        {
            var existing = (await _unitOfWork.AppointmentServices.GetByAppointmentIdAsync(appointmentId))
                .FirstOrDefault(x => x.MedicalServiceId == medicalServiceId);

            if (existing == null)
                return false;

            _unitOfWork.AppointmentServices.Delete(existing);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
