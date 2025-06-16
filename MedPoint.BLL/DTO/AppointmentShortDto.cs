namespace MedPoint.BLL.DTO
{
    public class AppointmentShortDto
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string PatientName { get; set; } = null!;
    }
}
