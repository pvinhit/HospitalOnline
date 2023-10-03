using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Notifications
{
	public interface INotificationRepository
	{
		Task<List<Notification>> GetAllNotifications();	
		Task CreateNotification(Notification notification);
	}
}
