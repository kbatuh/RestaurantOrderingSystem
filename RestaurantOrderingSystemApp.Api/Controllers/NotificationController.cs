using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrderingSystemApp.BusinessLayer.Abstract;
using RestaurantOrderingSystemApp.DtoLayer.NotificationDto;
using RestaurantOrderingSystemApp.EntityLayer.Entities;

namespace RestaurantOrderingSystemApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet]
        public IActionResult NotificationList()
        {
            return Ok(_notificationService.TGetListAll());
        }
        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }
        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationByFalse());
        }
        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {

            Notification notification = new Notification()
            {
                Description = createNotificationDto.Description,
                IconType = createNotificationDto.IconType,
                Status = false,
                Date = DateTime.Now
            };
            _notificationService.TAdd(notification);
            return Ok("Ekleme İşlemi Başarıyla Yapıldı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim Silindi");
        }
        [HttpGet("{id}")]

        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {

            Notification notification = new Notification()
            {
                NotificationID = updateNotificationDto.NotificationID,
                Description = updateNotificationDto.Description,
                IconType = updateNotificationDto.IconType,
                Status = updateNotificationDto.Status,
                Date = updateNotificationDto.Date,
            };
            _notificationService.TUpdate(notification);
            return Ok("Güncelleme İşlemi Başarıyla Yapıldı");
        }

        [HttpGet("NotificationStatusChange/{id}")]
        public IActionResult NotificationStatusChange(int id)
        {
            _notificationService.TNotificationStatusChange(id);
            return Ok("Güncelleme Yapıldı");
        }

        [HttpGet("AllNotificationStatusesChangeToTrue")]
        public IActionResult AllNotificationStatusesChangeToTrue()
        {
            _notificationService.TAllNotificationStatusesChangeToTrue();
            return Ok("Güncelleme Yapıldı");
        }
    }
}
