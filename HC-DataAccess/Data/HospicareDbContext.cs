using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HC_DataAccess.Data;

public partial class HospicareDbContext : DbContext
{
    public HospicareDbContext()
    {
    }

    public HospicareDbContext(DbContextOptions<HospicareDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Allergy> Allergies { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Billing> Billings { get; set; }

    public virtual DbSet<InsuranceCoverage> InsuranceCoverages { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<Medication> Medications { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPatient> UserPatients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HOME; Database=HospicareDB; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allergy>(entity =>
        {
            entity.HasKey(e => e.AllergyId).HasName("PK__Allergie__A49EBE62DFC45504");

            entity.Property(e => e.AllergyId).HasColumnName("AllergyID");
            entity.Property(e => e.AllergyName).HasMaxLength(100);
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Reaction).HasMaxLength(100);
            entity.Property(e => e.Severity).HasMaxLength(50);

            entity.HasOne(d => d.Patient).WithMany(p => p.Allergies)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Allergies__Patie__49C3F6B7");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCA2AE88F96C");

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
                .HasConstraintName("FK__Appointme__Patie__3E52440B");
        });

        modelBuilder.Entity<Billing>(entity =>
        {
            entity.HasKey(e => e.BillingId).HasName("PK__Billing__F1656D13AA4BF229");

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
                .HasConstraintName("FK__Billing__Appoint__4D94879B");

            entity.HasOne(d => d.Patient).WithMany(p => p.Billings)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Billing__Patient__4CA06362");
        });

        modelBuilder.Entity<InsuranceCoverage>(entity =>
        {
            entity.HasKey(e => e.InsuranceId).HasName("PK__Insuranc__74231BC437EEE495");

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
                .HasConstraintName("FK__Insurance__Patie__3B75D760");
        });

        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PK__MedicalR__FBDF78C9C548928E");

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
                .HasConstraintName("FK__MedicalRe__Patie__4222D4EF");

            entity.HasOne(d => d.Visit).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.VisitId)
                .HasConstraintName("FK__MedicalRe__Visit__4316F928");
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.HasKey(e => e.MedicationId).HasName("PK__Medicati__62EC1ADA91EECD9A");

            entity.Property(e => e.MedicationId).HasColumnName("MedicationID");
            entity.Property(e => e.Dosage).HasMaxLength(50);
            entity.Property(e => e.Frequency).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.RecordId).HasColumnName("RecordID");

            entity.HasOne(d => d.Record).WithMany(p => p.Medications)
                .HasForeignKey(d => d.RecordId)
                .HasConstraintName("FK__Medicatio__Recor__46E78A0C");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC3463A3F1ED3");

            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.HasInsurance).HasDefaultValue(false);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.PostalCode).HasMaxLength(20);
            entity.Property(e => e.State).HasMaxLength(50);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A58A99581A2");

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
                .HasConstraintName("FK__Payments__Billin__5165187F");

            entity.HasOne(d => d.Patient).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Payments__Patien__52593CB8");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A5900D018");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B6160522F1F79").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC9C37F00C");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E40301E792").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("RoleID");
        });

        modelBuilder.Entity<UserPatient>(entity =>
        {
            entity.HasKey(e => e.UserPatientId).HasName("PK__UserPati__A5147BCA52100289");

            entity.ToTable("UserPatient");

            entity.Property(e => e.UserPatientId).HasColumnName("UserPatientID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Patient).WithMany(p => p.UserPatients)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__UserPatie__Patie__619B8048");

            entity.HasOne(d => d.User).WithMany(p => p.UserPatients)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserPatie__UserI__60A75C0F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
