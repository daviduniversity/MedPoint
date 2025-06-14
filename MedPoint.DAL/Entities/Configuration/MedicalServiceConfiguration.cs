using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedPoint.DAL.Entities.Configuration
{
    public class MedicalServiceConfiguration : IEntityTypeConfiguration<MedicalService>
    {
        public void Configure(EntityTypeBuilder<MedicalService> builder)
        {
            builder.HasKey(ms => ms.Id);

            builder.Property(ms => ms.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ms => ms.Description)
                .HasMaxLength(1000);

            builder.Property(ms => ms.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasMany(ms => ms.AppointmentServices)
                .WithOne(asg => asg.MedicalService)
                .HasForeignKey(asg => asg.MedicalServiceId);
        }
    }
}
