using System.Collections.Generic;
using WebDevHomework.Models;

namespace WebDevHomework.Interfaces
{
    public interface ILinkReader
    {
        (IEnumerable<Link>, int) Get(string search, int skip);
        Link Get(int id);
        string GetFullLink(string shortLink);
    }
}