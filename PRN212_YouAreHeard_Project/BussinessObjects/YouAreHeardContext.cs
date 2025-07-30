using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BussinessObjects;

public partial class YouAreHeardContext : DbContext
{
    public YouAreHeardContext()
    {
    }

    public YouAreHeardContext(DbContextOptions<YouAreHeardContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AppointmentStatus> AppointmentStatuses { get; set; }

    public virtual DbSet<Arvregiman> Arvregimen { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Condition> Conditions { get; set; }

    public virtual DbSet<DoctorProfile> DoctorProfiles { get; set; }

    public virtual DbSet<DoctorRating> DoctorRatings { get; set; }

    public virtual DbSet<DoctorSchedule> DoctorSchedules { get; set; }

    public virtual DbSet<DoctorScheduleStatus> DoctorScheduleStatuses { get; set; }

    public virtual DbSet<Hivstatus> Hivstatuses { get; set; }

    public virtual DbSet<LabResult> LabResults { get; set; }

    public virtual DbSet<Medication> Medications { get; set; }

    public virtual DbSet<MedicationCombination> MedicationCombinations { get; set; }

    public virtual DbSet<Otpverification> Otpverifications { get; set; }

    public virtual DbSet<PatientCondition> PatientConditions { get; set; }

    public virtual DbSet<PatientProfile> PatientProfiles { get; set; }

    public virtual DbSet<PillRemindTime> PillRemindTimes { get; set; }

    public virtual DbSet<PregnancyStatus> PregnancyStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SupportRequest> SupportRequests { get; set; }

    public virtual DbSet<SupportRequestStatus> SupportRequestStatuses { get; set; }

    public virtual DbSet<SupportSubject> SupportSubjects { get; set; }

    public virtual DbSet<TestMetric> TestMetrics { get; set; }

    public virtual DbSet<TestMetricCombination> TestMetricCombinations { get; set; }

    public virtual DbSet<TestMetricType> TestMetricTypes { get; set; }

    public virtual DbSet<TestMetricValue> TestMetricValues { get; set; }

    public virtual DbSet<TestStage> TestStages { get; set; }

    public virtual DbSet<TestType> TestTypes { get; set; }

    public virtual DbSet<TreatmentPlan> TreatmentPlans { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConnectionString());
    }

    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
        return configuration["ConnectionStrings:DefaultConnection"];
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__D067651EC39F6166");

            entity.ToTable("Appointment");

            entity.Property(e => e.AppointmentId).HasColumnName("appointmentID");
            entity.Property(e => e.AppointmentStatusId).HasColumnName("appointmentStatusID");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DoctorId).HasColumnName("doctorID");
            entity.Property(e => e.DoctorNotes).HasColumnName("doctorNotes");
            entity.Property(e => e.DoctorScheduleId).HasColumnName("doctorScheduleID");
            entity.Property(e => e.IsAnonymous)
                .HasDefaultValue(false)
                .HasColumnName("isAnonymous");
            entity.Property(e => e.IsOnline).HasColumnName("isOnline");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.OrderCode).HasColumnName("orderCode");
            entity.Property(e => e.PatientId).HasColumnName("patientID");
            entity.Property(e => e.QueueNumber).HasColumnName("queueNumber");
            entity.Property(e => e.Reason)
                .HasMaxLength(255)
                .HasColumnName("reason");
            entity.Property(e => e.ZoomLink)
                .IsUnicode(false)
                .HasColumnName("zoomLink");

            entity.HasOne(d => d.AppointmentStatus).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.AppointmentStatusId)
                .HasConstraintName("FK__Appointme__appoi__31B762FC");

            entity.HasOne(d => d.Doctor).WithMany(p => p.AppointmentDoctors)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__Appointme__docto__2FCF1A8A");

            entity.HasOne(d => d.DoctorSchedule).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorScheduleId)
                .HasConstraintName("FK__Appointme__docto__32AB8735");

            entity.HasOne(d => d.Patient).WithMany(p => p.AppointmentPatients)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Appointme__patie__30C33EC3");
        });

        modelBuilder.Entity<AppointmentStatus>(entity =>
        {
            entity.HasKey(e => e.AppointmentStatusId).HasName("PK__Appointm__AA367B75B0A03E01");

            entity.ToTable("AppointmentStatus");

            entity.Property(e => e.AppointmentStatusId).HasColumnName("appointmentStatusID");
            entity.Property(e => e.AppointmentStatusName)
                .HasMaxLength(40)
                .HasColumnName("appointmentStatusName");
        });

        modelBuilder.Entity<Arvregiman>(entity =>
        {
            entity.HasKey(e => e.RegimenId).HasName("PK__ARVRegim__F42252494AB1C1CC");

            entity.ToTable("ARVRegimen");

            entity.Property(e => e.RegimenId).HasColumnName("regimenID");
            entity.Property(e => e.Duration)
                .HasMaxLength(100)
                .HasColumnName("duration");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.RegimenContraindications)
                .HasMaxLength(500)
                .HasColumnName("regimenContraindications");
            entity.Property(e => e.RegimenIndications)
                .HasMaxLength(500)
                .HasColumnName("regimenIndications");
            entity.Property(e => e.RegimenSideEffects)
                .HasMaxLength(500)
                .HasColumnName("regimenSideEffects");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__Blog__FA0AA70D403D0AC8");

            entity.ToTable("Blog");

            entity.Property(e => e.BlogId).HasColumnName("blogID");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Details).HasColumnName("details");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.User).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Blog__userID__5165187F");
        });

        modelBuilder.Entity<Condition>(entity =>
        {
            entity.HasKey(e => e.ConditionId).HasName("PK__Conditio__A297579C6DEDAFF3");

            entity.ToTable("Condition");

            entity.Property(e => e.ConditionId).HasColumnName("conditionID");
            entity.Property(e => e.ConditionName)
                .HasMaxLength(100)
                .HasColumnName("conditionName");
        });

        modelBuilder.Entity<DoctorProfile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__DoctorPr__CB9A1CDF1D544A2D");

            entity.ToTable("DoctorProfile");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Gender)
                .HasMaxLength(15)
                .HasColumnName("gender");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.LanguagesSpoken)
                .HasMaxLength(500)
                .HasColumnName("languagesSpoken");
            entity.Property(e => e.Specialties)
                .HasMaxLength(500)
                .HasColumnName("specialties");
            entity.Property(e => e.YearsOfExperience).HasColumnName("yearsOfExperience");

            entity.HasOne(d => d.User).WithOne(p => p.DoctorProfile)
                .HasForeignKey<DoctorProfile>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoctorPro__userI__619B8048");
        });

        modelBuilder.Entity<DoctorRating>(entity =>
        {
            entity.HasKey(e => new { e.DoctorId, e.UserId }).HasName("PK__DoctorRa__9E9D245B875D40FB");

            entity.ToTable("DoctorRating");

            entity.Property(e => e.DoctorId).HasColumnName("doctorID");
            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.RateValue).HasColumnName("rateValue");

            entity.HasOne(d => d.Doctor).WithMany(p => p.DoctorRatings)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoctorRat__docto__6B24EA82");

            entity.HasOne(d => d.User).WithMany(p => p.DoctorRatings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DoctorRat__userI__6C190EBB");
        });

        modelBuilder.Entity<DoctorSchedule>(entity =>
        {
            entity.HasKey(e => e.DoctorScheduleId).HasName("PK__DoctorSc__94013B1A20B0CED8");

            entity.ToTable("DoctorSchedule");

            entity.Property(e => e.DoctorScheduleId).HasColumnName("doctorScheduleID");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DoctorScheduleStatusId).HasColumnName("doctorScheduleStatusID");
            entity.Property(e => e.EndTime).HasColumnName("endTime");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.StartTime).HasColumnName("startTime");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.DoctorScheduleStatus).WithMany(p => p.DoctorSchedules)
                .HasForeignKey(d => d.DoctorScheduleStatusId)
                .HasConstraintName("FK__DoctorSch__docto__66603565");

            entity.HasOne(d => d.User).WithMany(p => p.DoctorSchedules)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__DoctorSch__userI__6754599E");
        });

        modelBuilder.Entity<DoctorScheduleStatus>(entity =>
        {
            entity.HasKey(e => e.DoctorScheduleStatusId).HasName("PK__DoctorSc__AEA2747A5872D8B6");

            entity.ToTable("DoctorScheduleStatus");

            entity.Property(e => e.DoctorScheduleStatusId).HasColumnName("doctorScheduleStatusID");
            entity.Property(e => e.DoctorScheduleStatusName)
                .HasMaxLength(40)
                .HasColumnName("doctorScheduleStatusName");
        });

        modelBuilder.Entity<Hivstatus>(entity =>
        {
            entity.HasKey(e => e.HivstatusId).HasName("PK__HIVStatu__6C0982C19508B731");

            entity.ToTable("HIVStatus");

            entity.Property(e => e.HivstatusId).HasColumnName("HIVStatusID");
            entity.Property(e => e.HivstatusName)
                .HasMaxLength(30)
                .HasColumnName("HIVStatusName");
        });

        modelBuilder.Entity<LabResult>(entity =>
        {
            entity.HasKey(e => e.LabResultId).HasName("PK__LabResul__BCC41DB84A594750");

            entity.ToTable("LabResult");

            entity.Property(e => e.LabResultId).HasColumnName("labResultID");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DoctorId).HasColumnName("doctorID");
            entity.Property(e => e.IsCustomized).HasColumnName("isCustomized");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.PatientId).HasColumnName("patientID");
            entity.Property(e => e.TestStageId).HasColumnName("testStageID");
            entity.Property(e => e.TestTypeId).HasColumnName("testTypeID");

            entity.HasOne(d => d.Doctor).WithMany(p => p.LabResultDoctors)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__LabResult__docto__14270015");

            entity.HasOne(d => d.Patient).WithMany(p => p.LabResultPatients)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__LabResult__patie__151B244E");

            entity.HasOne(d => d.TestStage).WithMany(p => p.LabResults)
                .HasForeignKey(d => d.TestStageId)
                .HasConstraintName("FK__LabResult__testS__123EB7A3");

            entity.HasOne(d => d.TestType).WithMany(p => p.LabResults)
                .HasForeignKey(d => d.TestTypeId)
                .HasConstraintName("FK__LabResult__testT__1332DBDC");
        });

        modelBuilder.Entity<Medication>(entity =>
        {
            entity.HasKey(e => e.MedicationId).HasName("PK__Medicati__C663CFBF9C4FEEBC");

            entity.ToTable("Medication");

            entity.Property(e => e.MedicationId).HasColumnName("medicationID");
            entity.Property(e => e.Contraindications)
                .HasMaxLength(500)
                .HasColumnName("contraindications");
            entity.Property(e => e.DosageMetric)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dosageMetric");
            entity.Property(e => e.Indications)
                .HasMaxLength(500)
                .HasColumnName("indications");
            entity.Property(e => e.MedicationName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("medicationName");
            entity.Property(e => e.SideEffect)
                .HasMaxLength(500)
                .HasColumnName("sideEffect");
        });

        modelBuilder.Entity<MedicationCombination>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MedicationCombination");

            entity.Property(e => e.Dosage).HasColumnName("dosage");
            entity.Property(e => e.Frequency).HasColumnName("frequency");
            entity.Property(e => e.MedicationId).HasColumnName("medicationID");
            entity.Property(e => e.RegimenId).HasColumnName("regimenID");

            entity.HasOne(d => d.Medication).WithMany()
                .HasForeignKey(d => d.MedicationId)
                .HasConstraintName("FK__Medicatio__medic__71D1E811");

            entity.HasOne(d => d.Regimen).WithMany()
                .HasForeignKey(d => d.RegimenId)
                .HasConstraintName("FK__Medicatio__regim__72C60C4A");
        });

        modelBuilder.Entity<Otpverification>(entity =>
        {
            entity.HasKey(e => e.Otpid).HasName("PK__OTPVerif__5C2EC5624F41C91F");

            entity.ToTable("OTPVerification");

            entity.Property(e => e.Otpid).HasColumnName("OTPID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.ExpiredDate)
                .HasColumnType("datetime")
                .HasColumnName("expiredDate");
            entity.Property(e => e.IsVerified)
                .HasDefaultValue(false)
                .HasColumnName("isVerified");
            entity.Property(e => e.Otp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("OTP");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.Otpverifications)
                .HasPrincipalKey(p => p.Email)
                .HasForeignKey(d => d.Email)
                .HasConstraintName("FK__OTPVerifi__email__2B0A656D");
        });

        modelBuilder.Entity<PatientCondition>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PatientCondition");

            entity.Property(e => e.ConditionId).HasColumnName("conditionID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Condition).WithMany()
                .HasForeignKey(d => d.ConditionId)
                .HasConstraintName("FK__PatientCo__condi__5EBF139D");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__PatientCo__UserI__5DCAEF64");
        });

        modelBuilder.Entity<PatientProfile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__PatientP__CB9A1CDF3782455A");

            entity.ToTable("PatientProfile");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userID");
            entity.Property(e => e.Gender)
                .HasMaxLength(15)
                .HasColumnName("gender");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.HivStatusId).HasColumnName("hivStatusID");
            entity.Property(e => e.PregnancyStatusId).HasColumnName("pregnancyStatusID");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.HivStatus).WithMany(p => p.PatientProfiles)
                .HasForeignKey(d => d.HivStatusId)
                .HasConstraintName("FK__PatientPr__hivSt__59FA5E80");

            entity.HasOne(d => d.PregnancyStatus).WithMany(p => p.PatientProfiles)
                .HasForeignKey(d => d.PregnancyStatusId)
                .HasConstraintName("FK__PatientPr__pregn__5AEE82B9");

            entity.HasOne(d => d.User).WithOne(p => p.PatientProfile)
                .HasForeignKey<PatientProfile>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PatientPr__userI__5BE2A6F2");
        });

        modelBuilder.Entity<PillRemindTime>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.DrinkDosage).HasColumnName("drinkDosage");
            entity.Property(e => e.MedicationId).HasColumnName("medicationID");
            entity.Property(e => e.Notes)
                .HasMaxLength(300)
                .HasColumnName("notes");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.TreatmentPlanId).HasColumnName("treatmentPlanID");

            entity.HasOne(d => d.Medication).WithMany()
                .HasForeignKey(d => d.MedicationId)
                .HasConstraintName("FK__PillRemin__medic__03F0984C");

            entity.HasOne(d => d.TreatmentPlan).WithMany()
                .HasForeignKey(d => d.TreatmentPlanId)
                .HasConstraintName("FK__PillRemin__treat__04E4BC85");
        });

        modelBuilder.Entity<PregnancyStatus>(entity =>
        {
            entity.HasKey(e => e.PregnancyStatusId).HasName("PK__Pregnanc__956280BC0C3BCDF8");

            entity.ToTable("PregnancyStatus");

            entity.Property(e => e.PregnancyStatusId).HasColumnName("pregnancyStatusID");
            entity.Property(e => e.PregnancyStatusName)
                .HasMaxLength(30)
                .HasColumnName("pregnancyStatusName");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__CD98460AF5A6E7D8");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("roleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<SupportRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__SupportR__E3C5DE510073E724");

            entity.ToTable("SupportRequest");

            entity.Property(e => e.RequestId).HasColumnName("requestID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.IsAnonymous)
                .HasDefaultValue(false)
                .HasColumnName("isAnonymous");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.RepliedBy).HasColumnName("repliedBy");
            entity.Property(e => e.RepliedDate)
                .HasColumnType("datetime")
                .HasColumnName("repliedDate");
            entity.Property(e => e.Reply).HasColumnName("reply");
            entity.Property(e => e.SubjectId).HasColumnName("subjectID");
            entity.Property(e => e.SupportRequestStatusId).HasColumnName("supportRequestStatusID");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.RepliedByNavigation).WithMany(p => p.SupportRequestRepliedByNavigations)
                .HasForeignKey(d => d.RepliedBy)
                .HasConstraintName("FK__SupportRe__repli__2739D489");

            entity.HasOne(d => d.Subject).WithMany(p => p.SupportRequests)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SupportRe__subje__25518C17");

            entity.HasOne(d => d.SupportRequestStatus).WithMany(p => p.SupportRequests)
                .HasForeignKey(d => d.SupportRequestStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SupportRe__suppo__2645B050");

            entity.HasOne(d => d.User).WithMany(p => p.SupportRequestUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__SupportRe__userI__245D67DE");
        });

        modelBuilder.Entity<SupportRequestStatus>(entity =>
        {
            entity.HasKey(e => e.SupportRequestStatusId).HasName("PK__SupportR__3ECBD5D7D568BF28");

            entity.ToTable("SupportRequestStatus");

            entity.Property(e => e.SupportRequestStatusId).HasColumnName("supportRequestStatusID");
            entity.Property(e => e.SupportRequestStatusName)
                .HasMaxLength(100)
                .HasColumnName("supportRequestStatusName");
        });

        modelBuilder.Entity<SupportSubject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__SupportS__ACF9A740C0DABE57");

            entity.ToTable("SupportSubject");

            entity.Property(e => e.SubjectId).HasColumnName("subjectID");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(100)
                .HasColumnName("subjectName");
        });

        modelBuilder.Entity<TestMetric>(entity =>
        {
            entity.HasKey(e => e.TestMetricId).HasName("PK__TestMetr__08C47663F11B442F");

            entity.ToTable("TestMetric");

            entity.HasIndex(e => e.TestMetricName, "UQ__TestMetr__C3AF6B868CAB78CF").IsUnique();

            entity.Property(e => e.TestMetricId).HasColumnName("testMetricID");
            entity.Property(e => e.TestMetricName)
                .HasMaxLength(50)
                .HasColumnName("testMetricName");
            entity.Property(e => e.TestMetricTypeId).HasColumnName("testMetricTypeID");
            entity.Property(e => e.UnitName)
                .HasMaxLength(50)
                .HasColumnName("unitName");

            entity.HasOne(d => d.TestMetricType).WithMany(p => p.TestMetrics)
                .HasForeignKey(d => d.TestMetricTypeId)
                .HasConstraintName("FK__TestMetri__testM__0E6E26BF");
        });

        modelBuilder.Entity<TestMetricCombination>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TestMetricCombination");

            entity.Property(e => e.TestMetricId).HasColumnName("testMetricID");
            entity.Property(e => e.TestTypeId).HasColumnName("testTypeID");

            entity.HasOne(d => d.TestMetric).WithMany()
                .HasForeignKey(d => d.TestMetricId)
                .HasConstraintName("FK__TestMetri__testM__1BC821DD");

            entity.HasOne(d => d.TestType).WithMany()
                .HasForeignKey(d => d.TestTypeId)
                .HasConstraintName("FK__TestMetri__testT__1AD3FDA4");
        });

        modelBuilder.Entity<TestMetricType>(entity =>
        {
            entity.HasKey(e => e.TestMetricTypeId).HasName("PK__TestMetr__061E5759C1578E0C");

            entity.ToTable("TestMetricType");

            entity.Property(e => e.TestMetricTypeId).HasColumnName("testMetricTypeID");
            entity.Property(e => e.TestMetricTypeName)
                .HasMaxLength(100)
                .HasColumnName("testMetricTypeName");
        });

        modelBuilder.Entity<TestMetricValue>(entity =>
        {
            entity.HasKey(e => new { e.LabResultId, e.TestMetricId }).HasName("PK__TestMetr__9C485ADE034C26DB");

            entity.ToTable("TestMetricValue");

            entity.Property(e => e.LabResultId).HasColumnName("labResultID");
            entity.Property(e => e.TestMetricId).HasColumnName("testMetricID");
            entity.Property(e => e.Value)
                .HasMaxLength(100)
                .HasColumnName("value");

            entity.HasOne(d => d.LabResult).WithMany(p => p.TestMetricValues)
                .HasForeignKey(d => d.LabResultId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TestMetri__labRe__17F790F9");

            entity.HasOne(d => d.TestMetric).WithMany(p => p.TestMetricValues)
                .HasForeignKey(d => d.TestMetricId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TestMetri__testM__18EBB532");
        });

        modelBuilder.Entity<TestStage>(entity =>
        {
            entity.HasKey(e => e.TestStageId).HasName("PK__TestStag__5128D0C13722F3EE");

            entity.ToTable("TestStage");

            entity.Property(e => e.TestStageId).HasColumnName("testStageID");
            entity.Property(e => e.TestStageName)
                .HasMaxLength(100)
                .HasColumnName("testStageName");
        });

        modelBuilder.Entity<TestType>(entity =>
        {
            entity.HasKey(e => e.TestTypeId).HasName("PK__TestType__C3BB01693CAD99B7");

            entity.ToTable("TestType");

            entity.Property(e => e.TestTypeId).HasColumnName("testTypeID");
            entity.Property(e => e.TestTypeName)
                .HasMaxLength(100)
                .HasColumnName("testTypeName");
        });

        modelBuilder.Entity<TreatmentPlan>(entity =>
        {
            entity.HasKey(e => e.TreatmentPlanId).HasName("PK__Treatmen__CDACE9B21FFD9C7D");

            entity.ToTable("TreatmentPlan");

            entity.Property(e => e.TreatmentPlanId).HasColumnName("treatmentPlanID");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DoctorId).HasColumnName("doctorID");
            entity.Property(e => e.IsCustomized).HasColumnName("isCustomized");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.PatientId).HasColumnName("patientID");
            entity.Property(e => e.RegimenId).HasColumnName("regimenID");

            entity.HasOne(d => d.Doctor).WithMany(p => p.TreatmentPlanDoctors)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__Treatment__docto__01142BA1");

            entity.HasOne(d => d.Patient).WithMany(p => p.TreatmentPlanPatients)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Treatment__patie__02084FDA");

            entity.HasOne(d => d.Regimen).WithMany(p => p.TreatmentPlans)
                .HasForeignKey(d => d.RegimenId)
                .HasConstraintName("FK__Treatment__regim__00200768");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__CB9A1CDF8EAC4775");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__AB6E61640EEEF61E").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FacebookPsid)
                .HasMaxLength(100)
                .HasColumnName("facebookPSID");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.RoleId).HasColumnName("roleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__User__roleID__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
