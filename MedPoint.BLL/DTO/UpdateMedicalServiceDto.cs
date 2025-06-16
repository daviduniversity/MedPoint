namespace MedPoint.BLL.DTO
{
    public class UpdateMedicalServiceDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
