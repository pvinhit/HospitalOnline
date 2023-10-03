using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Notifications
{
	public interface INotificationService
	{
		Task<List<NotificationDto>> GetAllNotifications();
		Task AddNotification(NotificationDto notificationDto);
	}
}
