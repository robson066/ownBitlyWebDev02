using WebDevHomework.Models;

namespace WebDevHomework.Interfaces
{
    public interface ILinkWriter
    {
        void Delete(int id);
        void AddLink(Link link);
        Link Create(Link link);
        Link Update(Link link);
    }
}