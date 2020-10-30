using EmployeeWebApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeEmergencyContact> EmployeeEmergencyContact { get; set; }
        public virtual DbSet<EmployeeExpenses> EmployeeExpenses { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseNpgsql("Server=192.168.1.165;Database=postgres;User Id=EmployeeDBUser;Password=HelloThere69!;Port=5432");
//            }
//        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasPostgresEnum(null, "employee_position_types", new[] { "Executive", "Management", "Workers" })
        //        .HasPostgresEnum(null, "employee_relationship_tpyes", new[] { "Father", "Mother", "GrandFather", "GrandMother", "Brother", "Sister", "Cousin", "Uncle", "Aunt", "Other" })
        //        .HasPostgresEnum(null, "gender_types", new[] { "Female", "Male" })
        //        .HasPostgresEnum(null, "phone_types", new[] { "cell", "home", "work" });

        //    modelBuilder.Entity<Employee>(entity =>
        //    {
        //        entity.ToTable("employee");

        //        entity.Property(e => e.Id)
        //            .HasColumnName("id")
        //            .ValueGeneratedNever();

        //        entity.Property(e => e.Birthdate)
        //            .IsRequired()
        //            .HasColumnName("birthdate")
        //            .HasColumnType("character varying");

        //        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

        //        entity.Property(e => e.FirstName)
        //            .IsRequired()
        //            .HasColumnName("first_name")
        //            .HasColumnType("character varying");

        //        entity.Property(e => e.HomeAddress)
        //            .IsRequired()
        //            .HasColumnName("home_address")
        //            .HasColumnType("character varying");

        //        entity.Property(e => e.LastName)
        //            .IsRequired()
        //            .HasColumnName("last_name")
        //            .HasColumnType("character varying");

        //        entity.Property(e => e.PaymentInformation)
        //            .IsRequired()
        //            .HasColumnName("payment_information")
        //            .HasColumnType("character varying");

        //        entity.Property(e => e.PhoneNumber)
        //            .HasColumnName("phone_number")
        //            .HasColumnType("character varying");

        //        entity.Property(e => e.Ssn)
        //            .IsRequired()
        //            .HasColumnName("ssn")
        //            .HasColumnType("character varying");

        //        entity.Property(e => e.StartDate)
        //            .HasColumnName("start_date")
        //            .HasColumnType("character varying");

        //        entity.Property(e => e.Title)
        //            .IsRequired()
        //            .HasColumnName("title")
        //            .HasColumnType("character varying");

        //        entity.Property(e => e.Wage).HasColumnName("wage");
        //    });

        //    modelBuilder.Entity<EmployeeEmergencyContact>(entity =>
        //    {
        //        entity.HasNoKey();

        //        entity.ToTable("employee_emergency_contact");

        //        entity.Property(e => e.Email)
        //            .HasColumnName("email")
        //            .HasColumnType("character varying");

        //        entity.Property(e => e.FirstName)
        //            .IsRequired()
        //            .HasColumnName("first_name")
        //            .HasColumnType("character varying");

        //        entity.Property(e => e.Id).HasColumnName("id");

        //        entity.Property(e => e.LastName)
        //            .IsRequired()
        //            .HasColumnName("last_name")
        //            .HasColumnType("character varying");

        //        entity.Property(e => e.PhoneNumber)
        //            .IsRequired()
        //            .HasColumnName("phone_number")
        //            .HasColumnType("character varying");

        //        entity.HasOne(d => d.IdNavigation)
        //            .WithMany()
        //            .HasForeignKey(d => d.Id)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("employee_emergency_contact_id_fkey");
        //    });

        //    modelBuilder.Entity<EmployeeExpenses>(entity =>
        //    {
        //        entity.HasNoKey();

        //        entity.ToTable("employee_expenses");

        //        entity.Property(e => e.CardEnabled).HasColumnName("card_enabled");

        //        entity.Property(e => e.CardNumber)
        //            .IsRequired()
        //            .HasColumnName("card_number")
        //            .HasColumnType("character varying");

        //        entity.Property(e => e.CurrentBalance).HasColumnName("current_balance");

        //        entity.Property(e => e.Id).HasColumnName("id");

        //        entity.Property(e => e.Reimbursement).HasColumnName("reimbursement");

        //        entity.HasOne(d => d.IdNavigation)
        //            .WithMany()
        //            .HasForeignKey(d => d.Id)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("employee_expenses_id_fkey");
        //    });

        //    modelBuilder.Entity<Person>(entity =>
        //    {
        //        entity.ToTable("person");

        //        entity.Property(e => e.Id).HasColumnName("id");

        //        entity.Property(e => e.BirthDate)
        //            .HasColumnName("birth_date")
        //            .HasColumnType("date");

        //        entity.Property(e => e.DataOwnerId).HasColumnName("data_owner_id");

        //        entity.Property(e => e.DeathDate)
        //            .HasColumnName("death_date")
        //            .HasColumnType("date");

        //        entity.Property(e => e.Father).HasColumnName("father");

        //        entity.Property(e => e.FirstName)
        //            .HasColumnName("first_name")
        //            .HasColumnType("character varying");

        //        entity.Property(e => e.LastName)
        //            .HasColumnName("last_name")
        //            .HasColumnType("character varying");

        //        entity.Property(e => e.Mother).HasColumnName("mother");

        //        entity.HasOne(d => d.FatherNavigation)
        //            .WithMany(p => p.InverseFatherNavigation)
        //            .HasForeignKey(d => d.Father)
        //            .HasConstraintName("person_father_fkey");

        //        entity.HasOne(d => d.MotherNavigation)
        //            .WithMany(p => p.InverseMotherNavigation)
        //            .HasForeignKey(d => d.Mother)
        //            .HasConstraintName("person_mother_fkey");
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}