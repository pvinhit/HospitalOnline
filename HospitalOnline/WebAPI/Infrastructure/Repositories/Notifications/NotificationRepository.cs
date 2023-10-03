using Domain.Entity;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Notifications
{
	public class NotificationRepository : INotificationRepository
	{
		private readonly DataDbContext _context;

		public NotificationRepository(DataDbContext context)
        {
			_context = context;
        }
		public async Task<List<Notification>> GetAllNotifications()
		{
			return await _context.Notifications.ToListAsync();
		}
		public async Task CreateNotification(Notification notification)
		{
			_context.Notifications.Add(notification);
			await _context.SaveChangesAsync();	
		}


	}
}
