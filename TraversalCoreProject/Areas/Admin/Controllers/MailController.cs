using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class MailController : Controller
    {
        [HttpGet]
        [Route("SendMail")]
        public IActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        [Route("SendMail")]
        public IActionResult SendMail(MailRequest mailRequest)
        {
            mailRequest.SendingTime = DateTime.Now;
            //MimeMessage kitinden bir nesne oluşturup bu nesneyi buna ekliyoruz.
            MimeMessage mimeMessage = new MimeMessage();
            //MimeKit sınıfından nesne türetiliyor ve gönderici bilgileri bu nesneye dolduruluyor.
            MailboxAddress mailboxAddressSender = new MailboxAddress("Traversal Core Project - Admin", "traversalcoreproject@batuhanyalin.com");
            mimeMessage.From.Add(mailboxAddressSender);

            //Alıcıyı burada tekrar aynı sınıfla oluşturuyoruz.
            MailboxAddress mailboxAddressReceiver = new MailboxAddress(mailRequest.ReceiverName, mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressReceiver);//To ile alıcıyı seçiyoruz.
            mimeMessage.Subject=mailRequest.Subject;
            mimeMessage.Date = mailRequest.SendingTime;
            //MailKit.Net.Smtp ile SmtpClient sınıfından nesne türetiyoruz.
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("mail.batuhanyalin.com",587,false);
            smtpClient.Authenticate("traversalcoreproject@batuhanyalin.com", "Vfv;apmH~$uU");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return View();
        }
    }
}
