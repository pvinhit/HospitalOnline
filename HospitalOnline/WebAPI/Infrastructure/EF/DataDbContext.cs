using Demo.Entities;
using Domain.Entity;
using Domain.Entity.Identity;
using Infrastructure.Configurations;
using Infrastructure.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.EF
{
	public class DataDbContext : IdentityDbContext<AppUser, AppRole, Guid>
	{
		public DataDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
			modelBuilder.ApplyConfiguration(new AppUserConfiguration());
			modelBuilder.ApplyConfiguration(new AppRoleConfiguration());

			modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
			modelBuilder.ApplyConfiguration(new DoctorConfiguration());
			modelBuilder.ApplyConfiguration(new PatientConfiguration());

			modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
			modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
			modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
			modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
			modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

			modelBuilder.Seed();
		}
		public DbSet<AppConfig> AppConfigs { get; set; }
		public DbSet<Doctor> Doctors { get; set; }	
		public DbSet<Patient> Patients { get; set; }
		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<MedicalHistory> MedicalHistories { get; set; }	
		public DbSet<PatientImage> PatientImages { get; set; }	
	}
}
