using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HC_DataAccess.Data;

public partial class HCDbContext : DbContext
{
    public HCDbContext()
    {
    }

    public HCDbContext(DbContextOptions<HCDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Allergy> Allergies { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Billing> Billings { get; set; }

    public virtual DbSet<DummyProduct> DummyProducts { get; set; }

    public virtual DbSet<InsuranceCoverage> InsuranceCoverages { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<Medication> Medications { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPatient> UserPatients { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=GAYATRI-8210;Database=HospicareDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allergy>(entity =>
        {
            entity.HasKey(e => e.AllergyId).HasName("PK__Allergie__A49EBE62E073CE97");

            entity.Property(e => e.AllergyId).HasColumnName("AllergyID");
            entity.Property(e => e.AllergyName).HasMaxLength(100);
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Reaction).HasMaxLength(100);
            entity.Property(e => e.Severity).HasMaxLength(50);

            entity.HasOne(d => d.Patient).WithMany(p => p.Allergies)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Allergies__Patie__5535A963");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCA23D3A1A27");

            entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
            entity.Property(e => e.AppointmentDate).HasColumnType("datetime");
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.Doctor).HasMaxLength(100);
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.ReasonForVisit).HasMaxLength(255);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Scheduled");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Appointme__Patie__571DF1D5");
        });

        modelBuilder.Entity<Billing>(entity =>
        {
            entity.HasKey(e => e.BillingId).HasName("PK__Billing__F1656D1345E5D011");

            entity.ToTable("Billing");

            entity.Property(e => e.BillingId).HasColumnName("BillingID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.PaymentMode).HasMaxLength(10);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(50)
                .HasColumnName("TransactionID");

            entity.HasOne(d => d.Appointment).WithMany(p => p.Billings)
                .HasForeignKey(d => d.AppointmentId)
                .HasConstraintName("FK__Billing__Appoint__5812160E");

            entity.HasOne(d => d.Patient).WithMany(p => p.Billings)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Billing__Patient__59063A47");
        });

        modelBuilder.Entity<DummyProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__dummy_Pr__3214EC07DCF5DD56");

            entity.ToTable("dummy_Products");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<InsuranceCoverage>(entity =>
        {
            entity.HasKey(e => e.InsuranceId).HasName("PK__Insuranc__74231BC4958FACF7");

            entity.ToTable("InsuranceCoverage");

            entity.Property(e => e.InsuranceId).HasColumnName("InsuranceID");
            entity.Property(e => e.ContactInfo).HasMaxLength(200);
            entity.Property(e => e.CoverageDetails).HasMaxLength(255);
            entity.Property(e => e.GroupNumber).HasMaxLength(50);
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.PolicyNumber).HasMaxLength(50);
            entity.Property(e => e.ProviderName).HasMaxLength(100);

            entity.HasOne(d => d.Patient).WithMany(p => p.InsuranceCoverages)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Insurance__Patie__5AEE82B9");
        });

        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PK__MedicalR__FBDF78C97F918F78");

            entity.Property(e => e.RecordId).HasColumnName("RecordID");
            entity.Property(e => e.Allergies).HasMaxLength(255);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Diagnosis).HasMaxLength(255);
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Prescription).HasMaxLength(255);
            entity.Property(e => e.Treatment).HasMaxLength(255);
            entity.Property(e => e.VisitId).HasColumnName("VisitID");

            entity.HasOne(d => d.Patient).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__MedicalRe__Patie__5CD6CB2B");

            entity.HasOne(d => d.Visit).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.VisitId)
                .HasConstraintName("FK__MedicalRe__Visit__5DCAEF64");
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.HasKey(e => e.MedicationId).HasName("PK__Medicati__62EC1ADAFB220C46");

            entity.Property(e => e.MedicationId).HasColumnName("MedicationID");
            entity.Property(e => e.Dosage).HasMaxLength(50);
            entity.Property(e => e.Frequency).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.RecordId).HasColumnName("RecordID");

            entity.HasOne(d => d.Record).WithMany(p => p.Medications)
                .HasForeignKey(d => d.RecordId)
                .HasConstraintName("FK__Medicatio__Recor__5FB337D6");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC346EE475D3A");

            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.AdmissionDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Diagnosis)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.DischargeDate).HasColumnType("datetime");
            entity.Property(e => e.EmergencyContact)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HasInsurance).HasDefaultValue(false);
            entity.Property(e => e.InsuranceNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InsuranceProvider)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PolicyNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Patients)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Patients__UserID__7D439ABD");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A58B9AE7A44");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.BillingId).HasColumnName("BillingID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.PaymentMode).HasMaxLength(10);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(50)
                .HasColumnName("TransactionID");

            entity.HasOne(d => d.Billing).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BillingId)
                .HasConstraintName("FK__Payments__Billin__619B8048");

            entity.HasOne(d => d.Patient).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Payments__Patien__628FA481");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3AC278051B");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B6160BE42C88E").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC3111C2C9");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4ED3E1CF3").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<UserPatient>(entity =>
        {
            entity.HasKey(e => e.UserPatientId).HasName("PK__UserPati__A5147BCAA816635D");

            entity.ToTable("UserPatient");

            entity.Property(e => e.UserPatientId).HasColumnName("UserPatientID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Patient).WithMany(p => p.UserPatients)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__UserPatie__Patie__6477ECF3");

            entity.HasOne(d => d.User).WithMany(p => p.UserPatients)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserPatie__UserI__656C112C");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId }).HasName("PK__UserRole__AF27604FE14FEE30");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__UserRoles__RoleI__01142BA1");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserRoles__UserI__00200768");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
