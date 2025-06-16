namespace MedPoint.BLL.DTO
{
    public class CreateAppointmentDto
    {
        public DateTime AppointmentDate { get; set; }
        public string? Notes { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public List<int> MedicalServiceIds { get; set; } = new();
    }
}
