using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Org.BouncyCastle.Crypto.Macs;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage message = new MimeMessage();
            MailboxAddress from = new MailboxAddress("Admin", "bblogprojem@gmail.com");
            message.From.Add(from);
            MailboxAddress to = new MailboxAddress("User", model.ReceiverMail);
            message.To.Add(to);
            var builder = new BodyBuilder();
            builder.TextBody = model.Content;
            message.Body = builder.ToMessageBody();
            message.Subject = model.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("bblogprojem@gmail.com", "ygsm vnax qmwp zxzi");
            client.Send(message);
            client.Disconnect(true);

            return View();
        }
    }
}
