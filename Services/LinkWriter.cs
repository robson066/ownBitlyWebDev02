using WebDev02_Homework.Interfaces;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;
using WebDevHomework.Repository;

namespace WebDevHomework.Services
{
    public class LinkWriter : ILinkWriter
    {
        private readonly ILinkRepository _linkRepository;

        public LinkWriter(ILinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }
        
        public Link Create(Link link)
            => _linkRepository.Create(link);

        public void Delete(int id)
            => _linkRepository.Delete(id);

        public Link Update(Link link)
            => _linkRepository.Update(link);
    }
}