
using DreamProperties.Models;
using DreamProperties.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DreamProperties.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContactMessageRepository contactMessageRepository;

        public HomeController(IContactMessageRepository contactMessageRepository)
        {
            this.contactMessageRepository = contactMessageRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string name, string email, string subject, string message)
        {
            var contactMessage = new ContactMessage
            {
                Name = name,
                Email = email,
                Subject = subject,
                Message = message
            };

            await this.contactMessageRepository.SaveContactMessages(contactMessage);

            return Json(new { success = true, responseText = "Your message has been successfully saved." });
        }
    }
}