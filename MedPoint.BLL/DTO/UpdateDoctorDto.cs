namespace MedPoint.BLL.DTO
{
    public class UpdateDoctorDto
    {
        public string FullName { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
