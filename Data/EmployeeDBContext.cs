using BlazorCrudApp.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudApp.Data
{
    public partial class EmployeeDBContext : IdentityDbContext<ApplicationUser>  
    {
        public EmployeeDBContext()
        {
        }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Si es necesario, agregar configuración de conexión aquí
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Asegúrate de invocar la base para configurar Identity correctamente

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Designation)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeGovtId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeGovtID");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
