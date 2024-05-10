using MailKit.Net.Smtp;
using MimeKit;
using RestaurantOrderingSystemApp.WebUI.Dtos.MailDtos;

namespace RestaurantOrderingSystemApp.WebUI.Services
{
    public class EmailService
    {
        public static void SendEmail(CreateMailDto createMailDto)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("B K Rezervasyon", "223593081bk@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailDto.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = createMailDto.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("223593081bk@gmail.com", "xckf wuoj ylzh rbgg");

            client.Send(mimeMessage);
            client.Disconnect(true);
        }
    }
}
