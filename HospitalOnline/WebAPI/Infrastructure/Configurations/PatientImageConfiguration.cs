using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configurations
{
	public class PatientImageConfiguration : IEntityTypeConfiguration<PatientImage>
	{
		public void Configure(EntityTypeBuilder<PatientImage> builder)
		{
			builder.ToTable("PatientImages");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).UseIdentityColumn();
			builder.Property(x => x.ImagePath).HasMaxLength(200).IsRequired(true);
			builder.Property(x => x.Caption).HasMaxLength(200);

			builder.HasOne(x => x.Patient).WithMany(x => x.PatientImages).HasForeignKey(x => x.patientId);
		}
	}
}
