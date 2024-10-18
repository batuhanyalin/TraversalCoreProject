using AutoMapper.Internal;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using TraversalCoreProject.DataAccessLayer.Context;
using TraversalCoreProject.EntityLayer.Concrete;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly TraversalContext _context;
        public PasswordChangeController(UserManager<AppUser> userManager, TraversalContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Mail);
            if (user == null)
            {
                return Json(new { success = false, message = "Bu e-posta adresine kayıtlı kullanıcı bulunamadı." });
            }
            else
            {
                string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new //Aşağıdaki atanan değişkenlerle birlikte buradaki belirlenen yere gidiyor.
                {
                    userId = user.Id,
                    token = passwordResetToken
                }, HttpContext.Request.Scheme); // Burada bir protokol belirliyoruz.

                //MimeMessage kitinden bir nesne oluşturup bu nesneyi buna ekliyoruz.
                MimeMessage mimeMessage = new MimeMessage();
                //MimeKit sınıfından nesne türetiliyor ve gönderici bilgileri bu nesneye dolduruluyor.
                MailboxAddress mailboxAddressSender = new MailboxAddress("Traversal Core Project - System", "traversalcoreproject@batuhanyalin.com");
                mimeMessage.From.Add(mailboxAddressSender);

                //Alıcıyı burada tekrar aynı sınıfla oluşturuyoruz.
                MailboxAddress mailboxAddressReceiver = new MailboxAddress(user.Name + " " + user.Surname, model.Mail);
                mimeMessage.To.Add(mailboxAddressReceiver);//To ile alıcıyı seçiyoruz.

                var bodyBuilder = new BodyBuilder(); //Burada mail içeriği için entity bazında bir ekleme işlemi yapılıyor.
                bodyBuilder.TextBody = passwordResetTokenLink;
                mimeMessage.Body = bodyBuilder.ToMessageBody(); // mesaj içeriğini gönderiyoruz.
                mimeMessage.Subject = "Şifre Değişiklik Talebi";
                mimeMessage.Date = DateTime.Now;
                //MailKit.Net.Smtp ile SmtpClient sınıfından nesne türetiyoruz.
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Connect("mail.batuhanyalin.com", 465, true);
                smtpClient.Authenticate("traversalcoreproject@batuhanyalin.com", "Vfv;apmH~$uU");
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);

                return Json(new { success = true });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ResetPassword(string userId, string token)
        {
            TempData["userId"] = userId;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var userId = TempData["userId"];
            var token = TempData["token"];
            if (userId == null || token == null)
            {
                return Json(new { success = false,message="" });
            }
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result= await _userManager.ResetPasswordAsync(user,token.ToString(),model.Password);
            if (result.Succeeded)
            {
                return Json(new { success = true, message = "Yeni parola başarıyla oluşturuldu." });
            }
            return View();
        }

    }
}
