namespace RestaurantOrderingSystemApp.WebUI.Dtos.NotificationDtos;
public class CreateNotificationDto
{
    public string IconType { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }
}

