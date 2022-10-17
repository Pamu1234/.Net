using System;
using System.Collections.Generic;
using JWT.Authentication.Server.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JWT.Authentication.Server.Core.Models
{
    public partial class EmployeemanagementDbContext : DbContext
    {
        public EmployeemanagementDbContext()
        {
        }

        public EmployeemanagementDbContext(DbContextOptions<EmployeemanagementDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Leaves> Leaves { get; set; } = null!;
        public virtual DbSet<LeaveApplication> LeaveApplications { get; set; } = null!;
        public virtual DbSet<LeaveBalance> LeaveBalances { get; set; } = null!;
        public virtual DbSet<LeaveStatus> LeaveStatuses { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.Property(e => e.DateOfLog).HasColumnType("datetime");

                entity.Property(e => e.EffectiveHours)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.LateTime).HasColumnType("datetime");

                entity.Property(e => e.TimeOut).HasColumnType("datetime");

                entity.Property(e => e.Timein).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Attendanc__Emplo__6FE99F9F");

                entity.HasOne(d => d.LeaveType)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.LeaveTypeId)
                    .HasConstraintName("FK__Attendanc__Leave__70DDC3D8");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(8, 3)");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Employees__Depar__3A81B327");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Employees__RoleI__3B75D760");
            });

            modelBuilder.Entity<Leaves>(entity =>
            {
                entity.HasKey(e => e.LeaveTypeId)
                    .HasName("PK__Leaves__43BE8F14865D89E6");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LeaveTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");
            });

            modelBuilder.Entity<LeaveApplication>(entity =>
            {
                entity.ToTable("LeaveApplication");

                entity.Property(e => e.DateOfApplication).HasColumnType("datetime");

                entity.Property(e => e.DateOfApproval).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Purpose)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.LeaveApplications)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__LeaveAppl__Emplo__45F365D3");

                entity.HasOne(d => d.LeaveType)
                    .WithMany(p => p.LeaveApplications)
                    .HasForeignKey(d => d.LeaveTypeId)
                    .HasConstraintName("FK__LeaveAppl__Leave__46E78A0C");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.LeaveApplications)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__LeaveAppl__Statu__47DBAE45");
            });

            modelBuilder.Entity<LeaveBalance>(entity =>
            {
                entity.ToTable("LeaveBalance");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.LeaveBalances)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__LeaveBala__Emplo__403A8C7D");

                entity.HasOne(d => d.LeaveType)
                    .WithMany(p => p.LeaveBalances)
                    .HasForeignKey(d => d.LeaveTypeId)
                    .HasConstraintName("FK__LeaveBala__Leave__412EB0B6");
            });

            modelBuilder.Entity<LeaveStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__LeaveSta__C8EE206392355725");

                entity.ToTable("LeaveStatus");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
