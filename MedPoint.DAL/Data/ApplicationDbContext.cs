using MedPoint.DAL.Entities;
using MedPoint.DAL.Entities.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MedPoint.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<MedicalService> MedicalServices => Set<MedicalService>();
        public DbSet<AppointmentService> AppointmentServices => Set<AppointmentService>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentServiceConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new MedicalServiceConfiguration());

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Др. Іван Петров", Specialization = "Кардіолог", Phone = "0501234561" },
                new Doctor { Id = 2, FullName = "Др. Марія Іваненко", Specialization = "Терапевт", Phone = "0501234562" },
                new Doctor { Id = 3, FullName = "Др. Сергій Коваль", Specialization = "Педіатр", Phone = "0501234563" },
                new Doctor { Id = 4, FullName = "Др. Олена Сидоренко", Specialization = "Дерматолог", Phone = "0501234564" },
                new Doctor { Id = 5, FullName = "Др. Дмитро Савчук", Specialization = "Офтальмолог", Phone = "0501234565" },
                new Doctor { Id = 6, FullName = "Др. Юлія Бондар", Specialization = "Невролог", Phone = "0501234566" },
                new Doctor { Id = 7, FullName = "Др. Олег Гнатюк", Specialization = "Травматолог", Phone = "0501234567" },
                new Doctor { Id = 8, FullName = "Др. Наталія Левченко", Specialization = "Психіатр", Phone = "0501234568" }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Андрій Козак", DateOfBirth = new DateTime(1990, 5, 10, 0, 0, 0, DateTimeKind.Utc), ContactPhone = "0671111111", Email = "andriy@example.com" },
                new Patient { Id = 2, FullName = "Ірина Мельник", DateOfBirth = new DateTime(1985, 8, 15, 0, 0, 0, DateTimeKind.Utc), ContactPhone = "0672222222", Email = "iryna@example.com" },
                new Patient { Id = 3, FullName = "Олександр Шевченко", DateOfBirth = new DateTime(1975, 2, 20, 0, 0, 0, DateTimeKind.Utc), ContactPhone = "0673333333", Email = "oleksandr@example.com" },
                new Patient { Id = 4, FullName = "Світлана Кравчук", DateOfBirth = new DateTime(2000, 11, 5, 0, 0, 0, DateTimeKind.Utc), ContactPhone = "0674444444", Email = "svitlana@example.com" },
                new Patient { Id = 5, FullName = "Василь Бондаренко", DateOfBirth = new DateTime(1999, 6, 18, 0, 0, 0, DateTimeKind.Utc), ContactPhone = "0675555555", Email = "vasyl@example.com" },
                new Patient { Id = 6, FullName = "Наталія Зінченко", DateOfBirth = new DateTime(1993, 9, 23, 0, 0, 0, DateTimeKind.Utc), ContactPhone = "0676666666", Email = "nataliya@example.com" },
                new Patient { Id = 7, FullName = "Богдан Паламарчук", DateOfBirth = new DateTime(1988, 4, 30, 0, 0, 0, DateTimeKind.Utc), ContactPhone = "0677777777", Email = "bohdan@example.com" },
                new Patient { Id = 8, FullName = "Ольга Дмитренко", DateOfBirth = new DateTime(1978, 12, 12, 0, 0, 0, DateTimeKind.Utc), ContactPhone = "0678888888", Email = "olha@example.com" }
            );

            modelBuilder.Entity<MedicalService>().HasData(
                new MedicalService { Id = 1, Name = "Кардіограма", Description = "Обстеження серця", Price = 250 },
                new MedicalService { Id = 2, Name = "Аналіз крові", Description = "Загальний аналіз", Price = 180 },
                new MedicalService { Id = 3, Name = "МРТ голови", Description = "Магнітно-резонансна томографія", Price = 1500 },
                new MedicalService { Id = 4, Name = "Консультація терапевта", Description = null, Price = 300 },
                new MedicalService { Id = 5, Name = "УЗД органів", Description = "Ультразвукове дослідження", Price = 400 },
                new MedicalService { Id = 6, Name = "Вакцинація", Description = "Щеплення від грипу", Price = 200 },
                new MedicalService { Id = 7, Name = "Очний огляд", Description = "Перевірка зору", Price = 150 },
                new MedicalService { Id = 8, Name = "Фізіотерапія", Description = "Процедури для відновлення", Price = 600 }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, AppointmentDate = DateTime.SpecifyKind(DateTime.Today.AddDays(1), DateTimeKind.Utc), DoctorId = 1, PatientId = 1, Notes = "Первинна консультація" },
                new Appointment { Id = 2, AppointmentDate = DateTime.SpecifyKind(DateTime.Today.AddDays(2), DateTimeKind.Utc), DoctorId = 2, PatientId = 2 },
                new Appointment { Id = 3, AppointmentDate = DateTime.SpecifyKind(DateTime.Today.AddDays(3), DateTimeKind.Utc), DoctorId = 3, PatientId = 3 },
                new Appointment { Id = 4, AppointmentDate = DateTime.SpecifyKind(DateTime.Today.AddDays(4), DateTimeKind.Utc), DoctorId = 4, PatientId = 4 },
                new Appointment { Id = 5, AppointmentDate = DateTime.SpecifyKind(DateTime.Today.AddDays(5), DateTimeKind.Utc), DoctorId = 5, PatientId = 5 },
                new Appointment { Id = 6, AppointmentDate = DateTime.SpecifyKind(DateTime.Today.AddDays(6), DateTimeKind.Utc), DoctorId = 6, PatientId = 6 },
                new Appointment { Id = 7, AppointmentDate = DateTime.SpecifyKind(DateTime.Today.AddDays(7), DateTimeKind.Utc), DoctorId = 7, PatientId = 7 },
                new Appointment { Id = 8, AppointmentDate = DateTime.SpecifyKind(DateTime.Today.AddDays(8), DateTimeKind.Utc), DoctorId = 8, PatientId = 8 }
            );

            modelBuilder.Entity<AppointmentService>().HasData(
                new AppointmentService { AppointmentId = 1, MedicalServiceId = 1 },
                new AppointmentService { AppointmentId = 1, MedicalServiceId = 2 },
                new AppointmentService { AppointmentId = 2, MedicalServiceId = 3 },
                new AppointmentService { AppointmentId = 3, MedicalServiceId = 4 },
                new AppointmentService { AppointmentId = 4, MedicalServiceId = 5 },
                new AppointmentService { AppointmentId = 5, MedicalServiceId = 6 },
                new AppointmentService { AppointmentId = 6, MedicalServiceId = 7 },
                new AppointmentService { AppointmentId = 7, MedicalServiceId = 8 }
            );
        }
    }
}
