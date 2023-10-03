using Application.DTOs;
using AutoMapper;
using Domain.Entity;
using Infrastructure.Repositories.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Notifications
{
	public class NotificationService : INotificationService
	{
		private readonly INotificationRepository _repository;
		private readonly IMapper _mapper;

		public NotificationService(INotificationRepository repository, IMapper mapper)
        {
			_repository = repository;
			_mapper = mapper;
        }
        public async Task<List<NotificationDto>> GetAllNotifications()
		{
			var notifications = await _repository.GetAllNotifications();
			return _mapper.Map<List<NotificationDto>>(notifications);	
		}

		public async Task AddNotification(NotificationDto notificationDto)
		{
			var notificationAdd = _mapper.Map<Notification>(notificationDto);
			await _repository.CreateNotification(notificationAdd);
		}
	}
}
