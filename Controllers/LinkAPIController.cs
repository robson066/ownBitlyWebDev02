using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebDev02_Homework.Models;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;

namespace WebDevHomework.Controllers
{
    [Route("api/links")]
    public class LinkAPIController : Controller
    {
        private readonly ILinkWriter _linkWriter;
        private readonly ILinkReader _linkReader;
        private int itemPerPage = 10;
        public LinkAPIController(ILinkReader linkReader, ILinkWriter linkWriter)
        {
            _linkReader = linkReader;
            _linkWriter = linkWriter;
        }

        [HttpOptions]
        public IActionResult Options()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Get([FromQuery]GetLinkRequest request)
        {
            var (links, count) = _linkReader
                    .Get(request.Search, (request.Page.Value - 1) * itemPerPage);
            var result = new SearchResult
            {
                PageInfo = new PageInfo
                {
                    CurrentPage = request.Page.Value,
                    MaxPage = count % itemPerPage == 0 ? count / itemPerPage : count / itemPerPage + 1
                },
                Items = links.Select(x => new LinkResult(x))
            };
            return Ok(result);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetSingleLink(int id) 
        {
            return Ok(_linkReader.Get(id));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _linkWriter.Delete(id);
            return new NoContentResult();
        }

        [Route("{id}")]
        [HttpOptions]
        public IActionResult GetSingleLinkOptions() 
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult EditLink([FromBody]CreateLinkRequest createLink)
        {
            return Ok(_linkWriter.Create(createLink.GetLink()));
        }

        [HttpPut]
        public IActionResult Create([FromBody]Link link)
        {
            return Ok(_linkWriter.Update(link));
        }
    }
}