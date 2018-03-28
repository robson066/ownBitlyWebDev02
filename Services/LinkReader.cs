using System.Collections.Generic;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;
using WebDevHomework.Repository;

namespace WebDevHomework.Services
{
    public class LinkReader : ILinkReader
    {
        private readonly LinkRepository _linkRepository;

        public LinkReader(LinkRepository linkRepository)
        {
            _linkRepository = linkRepository;
        }

        public (IEnumerable<Link>, int) Get(string search, int skip)
            => _linkRepository.Get(search, skip);

        public Link Get(int id)
            => _linkRepository.Get(id);

        public string GetFullLink(string shortLink)
            => _linkRepository.GetFullLink(shortLink);
        
    }
}