using MedPoint.BLL.DTO;
using MedPoint.BLL.Services.Interfaces;
using MedPoint.DAL.Entities;
using MedPoint.DAL.Repositories.Interfaces;

namespace MedPoint.BLL.Services
{
    public class MedicalServiceService : IMedicalServiceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicalServiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MedicalServiceDto>> GetAllAsync()
        {
            var services = await _unitOfWork.MedicalServices.GetAllAsync();
            return services.Select(MapToDto);
        }

        public async Task<IEnumerable<MedicalServiceDto>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            var services = await _unitOfWork.MedicalServices.GetByPriceRangeAsync(minPrice, maxPrice);
            return services.Select(MapToDto);
        }

        public async Task<MedicalServiceDetailsDto?> GetWithAppointmentsAsync(int id)
        {
            var service = await _unitOfWork.MedicalServices.GetWithAppointmentsAsync(id);
            if (service == null) return null;

            return new MedicalServiceDetailsDto
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                Price = service.Price,
                AppointmentIds = service.AppointmentServices.Select(asv => asv.AppointmentId).ToList()
            };
        }

        public async Task<int> CreateAsync(CreateMedicalServiceDto dto)
        {
            var entity = new MedicalService
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price
            };

            await _unitOfWork.MedicalServices.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdateAsync(int id, UpdateMedicalServiceDto dto)
        {
            var entity = await _unitOfWork.MedicalServices.GetByIdAsync(id);
            if (entity == null)
                return false;

            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.Price = dto.Price;

            _unitOfWork.MedicalServices.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _unitOfWork.MedicalServices.GetByIdAsync(id);
            if (entity == null)
                return false;

            _unitOfWork.MedicalServices.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        private static MedicalServiceDto MapToDto(MedicalService entity)
        {
            return new MedicalServiceDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price
            };
        }
    }
}
