using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configurations
{
	public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
	{
		public void Configure(EntityTypeBuilder<Appointment> builder)
		{
			builder.ToTable("Appoiments");

			builder.HasKey(a => a.Id);
			builder.HasKey(a => new { a.doctorId, a.patientId });
			builder.Property(a => a.Id).UseIdentityColumn();
			builder.Property(a => a.AppointmentDate).IsRequired();
			builder.Property(a => a.AppointmentTime).IsRequired();
			builder.Property(a => a.Status).HasMaxLength(200);

			builder.HasOne(a => a.Doctor).WithMany(a => a.Appointments).HasForeignKey(a => a.doctorId).OnDelete(DeleteBehavior.Restrict);
			builder.HasOne(a => a.Patient).WithMany(a => a.Appointments).HasForeignKey(a => a.patientId).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
