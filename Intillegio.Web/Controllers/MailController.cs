using Intillegio.DTOs.BindingModels;
using Intillegio.Web.Mails;
using Intillegio.Web.Mails.Contracts;
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

        [HttpPost]
        public IActionResult RequestCallBack(ServicesViewModel message)
        {
            _emailService.Callback(message.Callback);
            return RedirectToAction("SolutionDetails", "Solutions");
        }
    }
}
