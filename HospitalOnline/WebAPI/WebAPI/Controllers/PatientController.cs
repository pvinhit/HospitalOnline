using Application.DTOs;
using Application.Services.Patients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PatientController : ControllerBase
	{
		private readonly IPatientService _patientService;

		public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

		[HttpGet]
		public async Task<IActionResult> GetAllPatients()
		{
			var patients = await _patientService.GetAllPatients();
			return Ok(patients);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetPatientById(int id)
		{
			var patient = await _patientService.GetPatientById(id);
			if (patient == null)
			{
				return NotFound();
			}
			return Ok(patient);
		}

		[HttpPost]
		public async Task<IActionResult> AddPatient(PatientsDto patientsDto)
		{
			await _patientService.Add(patientsDto);
			return Ok("Add successfully");	
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdatePatient(PatientsDto patientsDto)
		{
			await _patientService.Update(patientsDto);
			return Ok("Update successfully");
		}

		[HttpDelete]
		public async Task<IActionResult> DeletePatient(int id)
		{
			await _patientService.Delete(id);
			return Ok("Delete successfully");
		}

		[HttpGet("{patientId}/images/{imageId}")]
		public async Task<IActionResult> GetImageById(int patientId, int imageId)
		{
			var image = await _patientService.GetImageById(imageId);
			if (image == null)
				return BadRequest("Cannot find product");
			return Ok(image);
		}

		[HttpPost("{patientId}/images")]
		public async Task<IActionResult> CreateImage(int patientId, [FromForm] PatientImageCreateDto patientImageDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var imageId = await _patientService.AddImage(patientId, patientImageDto);
			if (imageId == 0)
				return BadRequest();

			var image = await _patientService.GetImageById(imageId);

			return CreatedAtAction(nameof(GetImageById), new { id = imageId }, image);
		}


	}
}
