using Demo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configurations
{
	public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
	{
		public void Configure(EntityTypeBuilder<Doctor> builder)
		{
			builder.ToTable("Doctors");
			builder.Property(d => d.Id).UseIdentityColumn();
		}
	}
}
