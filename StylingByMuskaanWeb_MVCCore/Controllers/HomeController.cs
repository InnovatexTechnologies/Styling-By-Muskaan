using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StylingByMuskaanWeb_MVCCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace StylingByMuskaanWeb_MVCCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string Name, string Email, string Message)
        {
            // mail code
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("marwarisoftware@gmail.com");
            mail.To.Add("Stylingbymuskaan@gmail.com");
            mail.Subject = "Contact Mail (Styling By Muskaan Website)";

            mail.Body = "Name : " + Name + Environment.NewLine + "Email Id : " + Email + Environment.NewLine + "Message : " + Message;

            SmtpServer.Port = 587;
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.UseDefaultCredentials = true;
            SmtpServer.Credentials = new System.Net.NetworkCredential("marwarisoftware@gmail.com", "ilwtnwrwogtlxmxz");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

            return RedirectToAction("Index", "Home");
        }
    }
}