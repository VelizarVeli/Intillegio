using Intillegio.Services.Messaging.Emails;
using Intillegio.Services.Messaging.Emails.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Controllers
{
    public class MailController : Controller
    {
        private readonly IEmailService emailService;

        public MailController(IEmailService emailService)
        {
            ViewData["Message"] = "Your contact page.";
            this.emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendMessage(EmailMessage message)
        {
            emailService.Send(message);
            return RedirectToAction("Index", "Home");
        }
    }
}
