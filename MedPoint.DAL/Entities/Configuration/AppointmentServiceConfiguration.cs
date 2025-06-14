using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedPoint.DAL.Entities.Configuration
{
    public class AppointmentServiceConfiguration : IEntityTypeConfiguration<AppointmentService>
    {
        public void Configure(EntityTypeBuilder<AppointmentService> builder)
        {
            builder.HasKey(x => new { x.AppointmentId, x.MedicalServiceId });

            builder.HasOne(x => x.Appointment)
                .WithMany(a => a.AppointmentServices)
                .HasForeignKey(x => x.AppointmentId);

            builder.HasOne(x => x.MedicalService)
                .WithMany(ms => ms.AppointmentServices)
                .HasForeignKey(x => x.MedicalServiceId);
        }
    }
}
