namespace MedPoint.BLL.DTO
{
    public class PatientDetailsDto : PatientDto
    {
        public List<AppointmentDto> Appointments { get; set; } = new();
    }
}
