using System.Collections.Generic;
using WebDevHomework.Models;

namespace WebDev02_Homework.Interfaces
{
    public interface ILinkRepository
    {
        (IEnumerable<Link>, int) Get(string search, int skip);
        Link Get(int id);
        Link Create(Link link);
        Link Update(Link link);
        void Delete(int id);  
        string GetFullLink(string shortLink);
        
    }
}