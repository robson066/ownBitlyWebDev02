using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebDev02_Homework;
using WebDev02_Homework.Interfaces;
using WebDevHomework.Interfaces;
using WebDevHomework.Models;

namespace WebDevHomework.Repository
{
    public class LinkRepository : ILinkRepository
    {
        private readonly LinkDbContext _context;
        private readonly IHashDecoder _hashDecoder;
        private readonly IHashEncoder _hashEncoder;

        public LinkRepository(LinkDbContext context, IHashDecoder hashDecoder, IHashEncoder hashEncoder)
        {
            _context = context;
            _hashDecoder = hashDecoder;
            _hashEncoder = hashEncoder;
        }

        public Link Get(int id)
        {
            return _context.Links.Find(id);
        }

        public Link Create(Link link)
        {
            var random = new Random();
            link.Id = random.Next(100000, 1000000);
            // no hash collision check
            // can generate same hash for different links
            link.ShortUrl = _hashEncoder.Encode(link.Id);
            _context.Links.Add(link);
            _context.SaveChanges();
            return link;
        }

        public Link Update(Link link)
        {
            _context.Links.Attach(link);
            _context.Entry(link).State = EntityState.Modified;
            _context.SaveChanges();
            return link;
        }

        public void Delete(int linkId)
        {
            Link linkEntity = _context.Links.Find(linkId);
            _context.Links.Remove(linkEntity);
            _context.SaveChanges();
        }

        public string GetFullLink(string shortLink)
        {
            var id = _hashDecoder.Decode(shortLink);
            return _context.Links.SingleOrDefault(link => link.Id == id).FullUrl;
        }

        public (IEnumerable<Link>, int) Get(string search, int skip)
        {
            var linksFilteredByTitle = search != null ? _context.Links
                .Where(x => x.Title.ToLower()
                .Contains(search)) : _context.Links;
             
            var linksCount = linksFilteredByTitle.Count();

            var paginatedLink = linksFilteredByTitle
                .OrderBy(x => x.Id)
                .Skip(skip)
                .Take(20);

            return (paginatedLink, linksCount);
        }

    }
}