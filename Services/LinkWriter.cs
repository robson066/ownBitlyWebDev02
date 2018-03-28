using WebDevHomework.Interfaces;
using WebDevHomework.Models;
using WebDevHomework.Repository;

namespace WebDevHomework.Services
{
    public class LinkWriter : ILinkWriter
    {
        private readonly LinkRepository _linkRepository;

        public LinkWriter(LinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }
        public void AddLink(Link link)
        {
            _linkRepository.Create(link);
        }
        public Link Create(Link link)
            => _linkRepository.Create(link);

        public void Delete(int id)
            => _linkRepository.Delete(id);

        public Link Update(Link link)
            =>_linkRepository.Update(link);
    }
}