﻿namespace RestaurantOrderingSystemApp.WebUI.Dtos.NotificationDtos;

    public class UpdateNotificationDto
	{
		public int NotificationID { get; set; }
		public string IconType { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public bool Status { get; set; }
	}

