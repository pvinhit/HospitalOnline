using Application.Services.Doctors;
using Demo.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class DoctorController : ControllerBase
	{
		private readonly IDoctorService _doctorService;

		public DoctorController(IDoctorService doctorService)
		{
			_doctorService = doctorService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllDoctor()
		{
			var doctors = await _doctorService.GetAllDoctor();
			return Ok(doctors);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetDoctorById(int id)
		{
			var doctor = await _doctorService.GetDoctorById(id);
			if (doctor == null)
			{
				return NotFound();
			}
			return Ok(doctor);
		}

		[HttpPost]
		public async Task<IActionResult> AddDoctor([FromBody] DoctorDto doctorDto)
		{
			await _doctorService.AddDoctor(doctorDto);
			return Ok("Doctor added successfully");
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateDoctor([FromBody] DoctorDto doctorDto)
		{
			await _doctorService.UpdateDoctor(doctorDto);
			return Ok("Doctor updated successfully");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteDoctor(int id)
		{
			await _doctorService.DeleteDoctor(id);
			return Ok("Doctor deleted successfully");
		}
	}
}
