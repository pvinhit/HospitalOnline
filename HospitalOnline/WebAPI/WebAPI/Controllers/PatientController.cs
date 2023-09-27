using Application.DTOs;
using Application.Services.Patients;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Authorization;
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

		[HttpGet("getall")]
		public async Task<IActionResult> GetAllPatients()
		{
			var patients = await _patientService.GetAllPatients();
			return Ok(patients);
		}

		[HttpGet("pagingall")]
		public async Task<ActionResult<PagedList<PatientsDto>>> GetPagingPatients([FromQuery] PageParams patientParams)
		{
			var patients = await _patientService.GetPagingAllPatients(patientParams.PageSize, patientParams.PageNumber);
			return Ok(patients);
		}

		[HttpGet("pagedandsorted")]
		public async Task<ActionResult<PagedList<PatientsDto>>> GetPagedAndSortedPatients([FromQuery] int pageSize, [FromQuery] int pageNumber, [FromQuery] string orderBy)
		{
			var patients = await _patientService.GetPagedAndSortedAsync(pageSize, pageNumber, orderBy);
			return Ok(patients);
		}

		[HttpGet("filteredandpaged")]
		public async Task<ActionResult<PagedList<PatientsDto>>> GetFilteredAndPagedPatients([FromQuery] int pageSize, [FromQuery] int pageNumber, [FromQuery] string searchTerm)
		{
			var patients = await _patientService.GetFilteredAndPagedAsync(pageSize, pageNumber, searchTerm);
			return Ok(patients);
		}

		[HttpGet("filteredpagedSorted")]
		public async Task<ActionResult<PagedList<PatientsDto>>> GetPagedSortedAndFilteredAsync([FromQuery] PageParams productParams)
		{
			var products = await _patientService.GetPagedSortedAndFilteredAsync(productParams);
			return Ok(products);
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
			int imageId = await _patientService.AddImage(patientId, patientImageDto);
			if (imageId == 0)
				return BadRequest();
			return CreatedAtAction(nameof(GetImageById), new { id = imageId }, patientId);
		}

		[HttpPut("{patientId}/images/{imageId}")]
		public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateDto request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var result = await _patientService.UpdateImage(imageId, request);
			if (result == 0)
				return BadRequest();

			return Ok();
		}

		[HttpDelete("{patientId}/images/{imageId}")]
		public async Task<IActionResult> RemoveImage(int imageId)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var result = await _patientService.RemoveImage(imageId);
			if (result == 0)
				return BadRequest();

			return NoContent();
		}
	}
}
