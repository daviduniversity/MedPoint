namespace MedPoint.BLL.DTO
{
    public class CreatePatientDto
    {
        public string FullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string? ContactPhone { get; set; }
        public string? Email { get; set; }
    }
}
