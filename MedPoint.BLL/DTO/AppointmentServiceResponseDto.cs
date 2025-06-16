namespace MedPoint.BLL.DTO
{
    public class AppointmentServiceResponseDto
    {
        public int AppointmentId { get; set; }
        public int MedicalServiceId { get; set; }
        public string MedicalServiceName { get; set; } = null!;
        public decimal MedicalServicePrice { get; set; }
    }
}
