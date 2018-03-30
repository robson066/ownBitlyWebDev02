using System.Linq;
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
        private int skipItem = 0;
        public LinkController(ILinkReader linkReader, ILinkWriter linkWriter)
        {
            _linkReader = linkReader;
            _linkWriter = linkWriter;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var pageInfo = _linkReader.Get(null, skipItem);
            var alllinks = pageInfo.Item1.ToList();
            return View(alllinks);
        }

        [HttpPost("link/create")]
        public IActionResult Create(Link link)
        {
            var returnedLink = _linkWriter.Create(link);
            return RedirectToAction("Index");
        }

        [HttpDelete("link/delete")]
        public IActionResult Delete(int linkId)
        {
            _linkWriter.Delete(linkId);
            return RedirectToAction("Index");
        }


    }
}