using Application.Services.Appointments;
using Application.Services.Doctors;
using Application.Services.Patients;
using Application.Services.Role;
using Application.Services.User;
using Demo.Helper;
using Domain.Entity.Identity;
using Infrastructure.EF;
using Infrastructure.Repositories.Appointments;
using Infrastructure.Repositories.Doctors;
using Infrastructure.Repositories.Patients;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			//Add service to the container
			//services.AddDbContext<DataDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			services.AddDbContext<DataDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgresConnection")));

			services.AddAutoMapper(typeof(MapperDto));

			services.AddScoped<IDoctorService, DoctorService>();
			services.AddScoped<IDoctorRepository, DoctorRepository>();

			services.AddScoped<IPatientService, PatientService>();
			services.AddScoped<IPatientRepository, PatientRepository>();


			services.AddScoped<IAppointmentService, AppointmentService>();
			services.AddScoped<IAppointmentRepository, AppointmentRepository>();

			services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
			services.AddScoped<SignInManager<AppUser>, SignInManager<AppUser>>();
			services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();
			services.AddScoped<IRoleService, RoleService>();
			services.AddScoped<IUserService, UserService>();

			services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<DataDbContext>()
                .AddDefaultTokenProviders();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer"
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				  {
					{
					  new OpenApiSecurityScheme
					  {
						Reference = new OpenApiReference
						  {
							Type = ReferenceType.SecurityScheme,
							Id = "Bearer"
						  },
						  Scheme = "oauth2",
						  Name = "Bearer",
						  In = ParameterLocation.Header,
						},
						new List<string>()
					  }
					});
				string issuer = Configuration.GetValue<string>("Tokens:Issuer");
				string signingKey = Configuration.GetValue<string>("Tokens:Key");
				byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

				services.AddAuthentication(opt =>
				{
					opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(options =>
				{
					options.RequireHttpsMetadata = false;
					options.SaveToken = true;
					options.TokenValidationParameters = new TokenValidationParameters()
					{
						ValidateIssuer = true,
						ValidIssuer = issuer,
						ValidateAudience = true,
						ValidAudience = issuer,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ClockSkew = System.TimeSpan.Zero,
						IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
					};
				});
			});
		}


		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo v1");
			});
			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
