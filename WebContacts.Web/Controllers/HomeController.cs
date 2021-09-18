using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebContacts.BL.Repositories.MessageRepo;
using WebContacts.BL.Repositories.MessageTypeRepo;
using WebContacts.BL.ViewModels.Message;
using WebContacts.Web.Models;

namespace WebContacts.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ImessageTypeRepository _messageTypeRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IWebHostEnvironment _webHost;

        public HomeController(ILogger<HomeController> logger, ImessageTypeRepository messageTypeRepository , IMessageRepository messageRepository, IWebHostEnvironment webHost)
        {
            _logger = logger;
            _messageTypeRepository = messageTypeRepository;
            _messageRepository = messageRepository;
            _webHost = webHost;
        }

        public IActionResult Index(string message)
        {
            ViewBag.message = message;
            return View();
        }
        
        [HttpGet]
        public IActionResult ContactUs()
        {
            ViewBag.messageTypes = _messageTypeRepository.GetAllMessageTypes(true);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ContactUs(MessageCritieria message, IFormFile file)
        {
            if(message ==null)
            {
                ViewBag.messageTypes = _messageTypeRepository.GetAllMessageTypes(true);

                return View();
            }
            if(!ModelState.IsValid)
            {
                ViewBag.messageTypes = _messageTypeRepository.GetAllMessageTypes(true);
                return View();
            }
            if (file != null )
            {
              
                var path = Path.Combine(_webHost.WebRootPath, "UploadedFiles");
                string UniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(path, UniqueFileName);
                var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);
               
                message.FilePath = UniqueFileName;
            }
                
            var res = _messageRepository.Add(message);
            if(res.Result.Result)
            {
                return RedirectToAction("index",new { message= "Added" });

            }
            return RedirectToAction("index", new { message = "Faild" });
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
