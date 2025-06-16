namespace MedPoint.BLL.DTO
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? Notes { get; set; }

        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = null!;

        public int PatientId { get; set; }
        public string PatientName { get; set; } = null!;

        public List<AppointmentServiceDto> Services { get; set; } = new();
    }
}
