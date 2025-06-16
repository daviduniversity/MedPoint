namespace MedPoint.BLL.DTO
{
    public class CreateMedicalServiceDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
