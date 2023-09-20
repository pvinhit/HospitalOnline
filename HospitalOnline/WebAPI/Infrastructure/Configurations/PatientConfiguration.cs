using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configurations
{
	public class PatientConfiguration : IEntityTypeConfiguration<Patient>
	{
		public void Configure(EntityTypeBuilder<Patient> builder)
		{
			builder.ToTable("Patients");
			builder.Property(d => d.Id).UseIdentityColumn();
			builder.HasOne(p => p.Doctor).WithMany(p => p.Patients).HasForeignKey(a => a.doctorId);
		}
	}
}
