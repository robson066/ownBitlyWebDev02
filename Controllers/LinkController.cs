using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebDev02_Homework.Models;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;

namespace WebDevHomework.Controllers
{
    // Pozostawiłem ten kontroler do testowania. Wiem, że na następnych zajęciach nie będzie już potrzebny. 
    public class LinkController : Controller
    {
        private readonly ILinkWriter _linkWriter;
        private readonly ILinkReader _linkReader;
        private IHttpContextAccessor _accessor;
        private int itemsToSkip = 20;
        private string search = null;
        public LinkController(ILinkReader linkReader, ILinkWriter linkWriter, IHttpContextAccessor accessor)
        {
            _linkReader = linkReader;
            _linkWriter = linkWriter;
            WriteIpAddress(accessor);
        }

        [HttpGet]
        public IActionResult Index(int? page = 1)
        {
            var pageValue = page == null ? 1 : page.Value;
            var pageInfo = _linkReader.Get(search, (pageValue - 1)*itemsToSkip);
            var links = pageInfo.Item1.ToList();
            var linksCount = pageInfo.Item2;
            ViewBag.LinksCount = linksCount;
            return View(links);
        }

        [HttpPost]
        public IActionResult Create(Link link)
        {
            var returnedLink = _linkWriter.Create(link);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int linkId)
        {
            _linkWriter.Delete(linkId);
            return RedirectToAction("Index");
        }

        private void WriteIpAddress(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            // some methods to save on db
        }
    }
}