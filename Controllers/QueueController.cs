using ABCretail2.Models;
using ABCretail2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ABCretail2.Controllers
{
    public class QueueController : Controller
    {
        private readonly QueueService _queueService;

        public QueueController(QueueService queueService)
        {
            _queueService = queueService;
        }

        // GET: Queue/SendMessage
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        // POST: Queue/SendMessage
        [HttpPost]
        public async Task<IActionResult> SendMessage(QueueMessageModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _queueService.SendMessageAsync(model.Message);
                    return RedirectToAction("MessageSent");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while sending the message: " + ex.Message);
                }
            }

            return View(model);
        }

        // GET: Queue/MessageSent
        public IActionResult MessageSent()
        {
            return View();
        }
    }
}
