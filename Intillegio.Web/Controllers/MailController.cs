using Intillegio.Services.Emails;
using Intillegio.Services.Emails.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Intillegio.Web.Controllers
{
    public class MailController : BaseController
    {
        private readonly IEmailService _emailService;

        public MailController(IEmailService emailService)
        {
            ViewData["Message"] = "Your contact page.";
            this._emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendMessage(EmailMessage message)
        {
            _emailService.Send(message);
            return RedirectToAction("Index", "Home");
        }
    }
}
