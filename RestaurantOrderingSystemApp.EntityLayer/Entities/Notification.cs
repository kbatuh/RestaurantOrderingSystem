namespace RestaurantOrderingSystemApp.EntityLayer.Entities
{
    public class Notification
	{
        public int NotificationID { get; set; }
        public string IconType { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
