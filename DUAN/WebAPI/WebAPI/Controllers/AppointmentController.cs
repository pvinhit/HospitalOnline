using Application.Services.Appointments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppointmentController : ControllerBase
	{
		private readonly IAppointmentService _appointmentService;

		public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

		[HttpGet]
		public async Task<IActionResult> GetAllAppointments()
		{
			var appointments = await _appointmentService.GetAllAppointments();
			return Ok(appointments);
		}
    }
}
