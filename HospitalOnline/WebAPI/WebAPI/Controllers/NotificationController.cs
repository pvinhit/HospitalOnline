using Application.DTOs;
using Application.Service.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _service;

		public NotificationController(INotificationService service)
        {
            _service = service;
        }

		[HttpGet]
		public async Task<IActionResult> GetAllNotifications()
		{
			var notifications = await _service.GetAllNotifications();
			return Ok(notifications);	
		}

		[HttpPost]
		public async Task<IActionResult> CreateNotification(NotificationDto notificationDto)
		{
			await _service.AddNotification(notificationDto);
			return Ok();
		}
    }
}
