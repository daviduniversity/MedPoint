namespace MedPoint.DAL.Entities
{
    public class AppointmentService
    {
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; } = null!;

        public int MedicalServiceId { get; set; }
        public MedicalService MedicalService { get; set; } = null!;
    }
}
