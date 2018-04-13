using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebDev02_Homework.Models;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;

namespace WebDevHomework.Controllers
{
    //[Produces("application/json")]
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

        // //GET api/links/{id}
        // [HttpGet("{page}")]
        // public IActionResult Index(int page)
        // {
        //     var result = _linkReader.Get(page);
        //     return Ok(result);
        // }

        //GET api/links/?search={string}&page={int}
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

        //DELETE api/links/{id}
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _linkWriter.Delete(id);
            return Ok();
        }

        //POST api/links
        [HttpPost]
        public IActionResult Post([FromBody]CreateLinkRequest createLink)
        {
            return Ok(_linkWriter.Create(createLink.GetLink()));
        }

        //POST api/links
        [HttpPut]
        public IActionResult Put([FromBody]Link link)
        {
            return Ok(_linkWriter.Update(link));
        }
    }
}