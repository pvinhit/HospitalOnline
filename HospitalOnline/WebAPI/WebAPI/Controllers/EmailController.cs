using Infrastructure.Email;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmailController : ControllerBase
	{
		private readonly IEmailService _emailService;

		public EmailController(IEmailService emailService)
		{
			_emailService = emailService;
		}

		[HttpPost("send")]
		public async Task<IActionResult> SendEmailAsync([FromBody] EmailRequest request)
		{
			// Lấy thông tin từ request (địa chỉ email, tiêu đề, nội dung)
			string toEmail = request.ToEmail;
			string subject = request.Subject;
			string body = request.Body;

			// Gửi email
			await _emailService.SendEmailAsync(toEmail, subject, body);

			return Ok("Email sent successfully");
		}
	}
}
