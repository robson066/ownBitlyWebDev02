using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pioneer.Pagination;
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
        private readonly IPaginatedMetaService _paginatedMetaService;
        private int itemsPerPage = 10;
        public LinkController(ILinkReader linkReader, ILinkWriter linkWriter, IPaginatedMetaService paginatedMetaService)
        {
            _linkReader = linkReader;
            _linkWriter = linkWriter;
            _paginatedMetaService = paginatedMetaService;
        }

        [HttpGet]
        public IActionResult Index(int? index = 1)
        {
            var page = index == null ? 1 : index.Value; 
            var pageInfo = _linkReader.Get(null, (page - 1) * itemsPerPage);
            var links = pageInfo.Item1.ToList();
            var linksCount = pageInfo.Item2;
            ViewBag.PaginatedMeta = _paginatedMetaService.GetMetaData(linksCount, page, itemsPerPage);
            return View(links);
        }

        [HttpPost]
        public IActionResult Create(Link link)
        {
            var returnedLink = _linkWriter.Create(link);
            return RedirectToAction("Index");
        }

        [Route("delete/{linkId}")]
        [HttpGet]
        public IActionResult Delete(int linkId)
        {
            _linkWriter.Delete(linkId);
            return RedirectToAction("Index");
        }

        [Route("links/{id}")]   
        public IActionResult ReuteToIndex(int? id = 1)
        {
            return RedirectToPage("Index");
        }


    }
}