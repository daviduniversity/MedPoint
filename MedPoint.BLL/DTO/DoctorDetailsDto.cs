namespace MedPoint.BLL.DTO
{
    public class DoctorDetailsDto : DoctorDto
    {
        public List<AppointmentShortDto> Appointments { get; set; } = new();
    }
}
