namespace MedPoint.BLL.DTO
{
    public class MedicalServiceDetailsDto : MedicalServiceDto
    {
        public List<int> AppointmentIds { get; set; } = new();
    }
}
