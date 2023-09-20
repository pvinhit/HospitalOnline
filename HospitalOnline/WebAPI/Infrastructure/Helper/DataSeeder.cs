using Demo.Entities;
using Domain.Entity;
using Domain.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace Infrastructure.Helper
{
    public static class DataSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor()
                {
                    Id = 1,
                    FirstName = "Tran",
                    LastName = "Loi",
                    Specialty = "Da Lieu",
                    Phone = "0932123587"
                }
            );
            modelBuilder.Entity<Patient>().HasData(
                new Patient()
                {
                    Id = 1,
					doctorId = 1,
					FirstName = "Pham",
                    LastName = "Vinh",
                    DateOfBirth = new DateTime(2000, 04, 10),
                    Gender = "Nam",
                    Phone = "0334787899",
                    Address = "Hue",
                    NumberBHYT = "BH24612222152122"
                },
                new Patient()
                {
                    Id = 2,
					doctorId = 1,
					FirstName = "My",
                    LastName = "Duyen",
                    DateOfBirth = new DateTime(2000, 12, 12),
                    Gender = "Nu",
                    Phone = "09123456789",
                    Address = "Quang Nam",
                    NumberBHYT = "BH24612222152199"
				}
            );
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment()
                {
                    Id = 1,
		            AppointmentDate = new DateTime(2023,09,20),
                    AppointmentTime = new DateTime(2023,09,20,10,30,00),
                    Status = "Success",
                    patientId = 2, 
                    doctorId = 1,
	            }
            );
			// any guid
			var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
			var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
			modelBuilder.Entity<AppRole>().HasData(new AppRole
			{
				Id = roleId,
				Name = "admin",
				NormalizedName = "admin",
				Description = "Administrator role"
			});

			var hasher = new PasswordHasher<AppUser>();
			modelBuilder.Entity<AppUser>().HasData(new AppUser
			{
				Id = adminId,
				UserName = "admin",
				NormalizedUserName = "admin",
				Email = "tedu.international@gmail.com",
				NormalizedEmail = "tedu.international@gmail.com",
				EmailConfirmed = true,
				PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
				SecurityStamp = string.Empty,
				FirstName = "Toan",
				LastName = "Bach",
				Dob = new DateTime(2020, 01, 31)
			});

			modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
			{
				RoleId = roleId,
				UserId = adminId
			});
		}
    }
}
