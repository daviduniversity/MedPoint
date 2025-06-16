namespace MedPoint.BLL.DTO
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
