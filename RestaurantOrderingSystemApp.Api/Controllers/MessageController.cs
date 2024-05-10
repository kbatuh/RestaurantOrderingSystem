using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrderingSystemApp.BusinessLayer.Abstract;
using RestaurantOrderingSystemApp.DtoLayer.AboutDto;
using RestaurantOrderingSystemApp.DtoLayer.MessageDto;
using RestaurantOrderingSystemApp.EntityLayer.Entities;

namespace RestaurantOrderingSystemApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]

        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            Message message = new Message()
            {
                Mail = createMessageDto.Mail,
                MessageContent = createMessageDto.MessageContent,
                MessageSendDate = DateTime.Now,
                NameSurname = createMessageDto.NameSurname,
                Phone = createMessageDto.Phone,
                Status = false,
                Subject = createMessageDto.Subject,
            };

            _messageService.TAdd(message);
            return Ok("Mesaj başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            _messageService.TDelete(value);
            return Ok("Mesaj Alanı Silindi");
        }

        [HttpPut]

        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            Message message = new Message()
            {
                Mail = updateMessageDto.Mail,
                MessageContent = updateMessageDto.MessageContent,
                MessageSendDate = updateMessageDto.MessageSendDate,
                NameSurname = updateMessageDto.NameSurname,
                Phone = updateMessageDto.Phone,
                Status = false,
                Subject = updateMessageDto.Subject,
                MessageID = updateMessageDto.MessageID, 
            };
            _messageService.TUpdate(message);
            return Ok("Mesaj Bilgisi Güncellendi ");
        }

        [HttpGet("{id}")]

        public IActionResult GetMessage(int id)
        {
            var value = _messageService.TGetByID(id);
            return Ok(value);
        }

        [HttpGet("MessageCountByStatusFalse")]
        public IActionResult MessageCountByStatusFalse()
        {
            return Ok(_messageService.TMessageCountByStatusFalse());
        }

        [HttpGet("GetAllMessageByFalse")]
        public IActionResult GetAllMessageByFalse()
        {
            return Ok(_messageService.TGetAllMessageByFalse());
        }

        [HttpGet("MessageStatusChange/{id}")]
        public IActionResult MessageStatusChange(int id)
        {
            _messageService.TMessageStatusChange(id);
            return Ok("Güncelleme Yapıldı");
        }

        [HttpGet("AllMessageStatusesChangeToTrue")]
        public IActionResult AllMessageStatusesChangeToTrue()
        {
            _messageService.TAllMessageStatusesChangeToTrue();
            return Ok("Güncelleme Yapıldı");
        }
    }
}
