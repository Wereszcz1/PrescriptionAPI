using Microsoft.EntityFrameworkCore;
using PrescriptionAPI.Models;

namespace PrescriptionAPI.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> Prescription_Medicaments { get; set; }

    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<PrescriptionMedicament>()
              .HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });

        modelBuilder.Entity<PrescriptionMedicament>()
            .HasOne(pm => pm.Medicament)
             .WithMany(m => m.Prescription_Medicaments)
              .HasForeignKey(pm => pm.IdMedicament);

        modelBuilder.Entity<PrescriptionMedicament>()
            .HasOne(pm => pm.Prescription)
             .WithMany(p => p.Prescription_Medicaments)
              .HasForeignKey(pm => pm.IdPrescription);

        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.Patient)
             .WithMany(pa => pa.Prescriptions)
              .HasForeignKey(p => p.IdPatient);

        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.Doctor)
             .WithMany(d => d.Prescriptions)
              .HasForeignKey(p => p.IdDoctor);

        var baseDate = new DateTime(2025, 5, 13);

        modelBuilder.Entity<Doctor>().HasData(
            new Doctor
            {
                IdDoctor = 1, 
                 FirstName = "Zbigniew", 
                  LastName = "Religa", 
                   Email = "z.religa@poradnia.pl"
            },
            new Doctor
            {
                IdDoctor = 2, 
                 FirstName = "Mariola", 
                  LastName = "Bieda", 
                   Email = "m.bieda@poradnia.pl"
            },
            new Doctor
            {
                IdDoctor = 3, 
                 FirstName = "Jagoda", 
                  LastName = "Bieda", 
                   Email = "j.bieda@poradnia.pl"
            },
            new Doctor
            {
                IdDoctor = 4,
                 FirstName = "Karol",
                  LastName = "Wójcik",
                   Email = "k.wojcik@poradnia.pl"
            },
            new Doctor
            {
                IdDoctor = 5,
                 FirstName = "Monika",
                  LastName = "Nowak",
                   Email = "m.nowak@poradnia.org"
            }
            
        );

        modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                IdPatient = 1, 
                 FirstName = "Anna", 
                  LastName = "Sokołowska", 
                   Birthdate = new DateTime(1988, 7, 19)
            },
            new Patient
            {
                IdPatient = 2, 
                 FirstName = "Michał", 
                  LastName = "Wereszczyński", 
                   Birthdate = new DateTime(1993, 11, 11)
            },
            new Patient
            {
                IdPatient = 3, 
                 FirstName = "Marcin", 
                  LastName = "Seliga", 
                   Birthdate = new DateTime(1989, 12, 2)
            },
            new Patient
            {
                IdPatient = 4, 
                 FirstName = "Adrianna", 
                  LastName = "Lazer-Deja", 
                   Birthdate = new DateTime(1994, 1, 22)
            },
            new Patient
            {
                IdPatient = 5,
                 FirstName = "Tomasz",
                  LastName = "Kowal",
                   Birthdate = new DateTime(1975, 3, 9)
            },
            new Patient
            {
                IdPatient = 6,
                 FirstName = "Katarzyna",
                  LastName = "Matejak",
                   Birthdate = new DateTime(2000, 9, 24)
            }
        );

        modelBuilder.Entity<Medicament>().HasData(
            new Medicament
            {
                IdMedicament = 1, 
                 Name = "Apap", 
                  Description = "Lek przeciwbólowy.", 
                   Type = "Tabletka"
            },
            new Medicament
            {
                IdMedicament = 2, 
                 Name = "Ibuprom RR Max", 
                  Description = "Lek przeciwbólowy, przeciwzapalny i przeciwgorączkowy.", 
                   Type = "Kapsułka"
            },
            new Medicament
            {
                IdMedicament = 3, 
                 Name = "Amotaks", 
                  Description = "Antybiotyk w leczeniu górnych dróg oddechowych.", 
                   Type = "Tabletka"
            },
            new Medicament
            {
                IdMedicament = 4, 
                 Name = "Budezonid", 
                  Description = "Leczenie płuc.", 
                   Type = "Inhalacja"
            },
            new Medicament
            {
                IdMedicament = 5, 
                 Name = "Clatra", 
                  Description = "Lek przeciwalergiczny.", 
                   Type = "Tabletka"
            },
            new Medicament
            {
                IdMedicament = 6,
                 Name = "No-Spa",
                  Description = "Lek rozkurczowy stosowany przy bólach brzucha.",
                   Type = "Tabletka"
            },
            new Medicament
            {
                IdMedicament = 7,
                 Name = "Rutinoscorbin",
                  Description = "Wzmacnia odporność, zawiera witaminę C i rutynę.",
                   Type = "Tabletka"
            },
            new Medicament
            {
                IdMedicament = 8,
                 Name = "Neosine",
                  Description = "Wspomaga leczenie infekcji wirusowych.",
                   Type = "Syrop"
            }
        );

        modelBuilder.Entity<Prescription>().HasData(
            new Prescription
            {
                IdPrescription = 1, 
                 Date = baseDate.AddDays(-7), 
                  DueDate = baseDate.AddDays(15), 
                   IdDoctor = 1, 
                    IdPatient = 1
            },
            new Prescription
            {
                IdPrescription = 2, 
                 Date = baseDate.AddDays(-8), 
                  DueDate = baseDate.AddDays(29), 
                   IdDoctor = 1, 
                    IdPatient = 3
            },
            new Prescription
            {
                IdPrescription = 3, 
                 Date = baseDate.AddDays(-3), 
                  DueDate = baseDate.AddDays(27), 
                   IdDoctor = 2, 
                    IdPatient = 2
            },
            new Prescription
            {
                IdPrescription = 4, 
                 Date = baseDate.AddDays(-4), 
                  DueDate = baseDate.AddDays(20), 
                   IdDoctor = 1, 
                    IdPatient = 4
            },
            new Prescription
            {
                IdPrescription = 5, 
                 Date = baseDate, 
                  DueDate = baseDate.AddDays(10), 
                   IdDoctor = 3, 
                    IdPatient = 4
            },
            new Prescription
            {
                IdPrescription = 6,
                 Date = baseDate.AddDays(-10),
                  DueDate = baseDate.AddDays(5),
                   IdDoctor = 4,
                    IdPatient = 5
            },
            new Prescription
            {
                IdPrescription = 7,
                 Date = baseDate.AddDays(-2),
                  DueDate = baseDate.AddDays(14),
                   IdDoctor = 5,
                    IdPatient = 6
            },
            new Prescription
            {
                IdPrescription = 8,
                 Date = baseDate.AddDays(-1),
                  DueDate = baseDate.AddDays(7),
                   IdDoctor = 2,
                    IdPatient = 2
            }
        );

        modelBuilder.Entity<PrescriptionMedicament>().HasData(
            new PrescriptionMedicament
            {
                IdPrescription = 1, 
                 IdMedicament = 1, 
                  Dose = 1, 
                   Details = "1 tabletka 2 razy dziennie, przy większych bólach 3 razy dziennie."
            },
            new PrescriptionMedicament
            {
                IdPrescription = 1, 
                 IdMedicament = 2, 
                  Dose = 1, 
                   Details = "1 kapsułka co 4 godziny w ciągu dnia."
            },
            new PrescriptionMedicament
            {
                IdPrescription = 2, 
                 IdMedicament = 3, 
                  Dose = 2, 
                   Details = "2 tabletki co 12 godzin, przez 3 dni."
            },
            new PrescriptionMedicament
            {
                IdPrescription = 3, 
                 IdMedicament = 4, 
                  Dose = 1, 
                   Details = "1 inhalacja rano i wieczorem."
            },
            new PrescriptionMedicament
            {
                IdPrescription = 4, 
                 IdMedicament = 5, 
                  Dose = 1, 
                   Details = "1 tabletka rano. W razie zwiększenia objawów wziąć drugą tabletkę, ale nie wcześniej niż 4 godziny po pierwszej."
            },
            new PrescriptionMedicament
            {
                IdPrescription = 5, 
                 IdMedicament = 1, 
                  Dose = 1, 
                   Details = "1 tabletka co 4 godzin w razie bólu"
            },
            new PrescriptionMedicament
            {
                IdPrescription = 5, 
                 IdMedicament = 4, 
                  Dose = 1, 
                   Details = "1 inhalacja wieczorem"
            },
            new PrescriptionMedicament
            {
                IdPrescription = 6,
                 IdMedicament = 6,
                  Dose = 2,
                   Details = "2 tabletki dziennie, rano i wieczorem przez 3 dni."
            },
            new PrescriptionMedicament
            {
                IdPrescription = 6,
                 IdMedicament = 1,
                  Dose = 1,
                   Details = "W razie bólu głowy – 1 tabletka."
            },
            new PrescriptionMedicament
            {
                IdPrescription = 7,
                 IdMedicament = 7,
                  Dose = 1,
                   Details = "1 tabletka dziennie na odporność."
            },
            new PrescriptionMedicament
            {
                IdPrescription = 7,
                 IdMedicament = 5,
                  Dose = 1,
                   Details = "1 tabletka w przypadku reakcji alergicznej."
            },
            new PrescriptionMedicament
            {
                IdPrescription = 8,
                 IdMedicament = 8,
                  Dose = 3,
                   Details = "3 łyżeczki dziennie przez 5 dni."
            },
            new PrescriptionMedicament
            {
                IdPrescription = 8,
                 IdMedicament = 2,
                  Dose = 1,
                   Details = "Tylko w razie gorączki – nie częściej niż co 6 godzin."
            }
        );
    }
}