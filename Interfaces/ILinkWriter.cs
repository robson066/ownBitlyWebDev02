using WebDevHomework.Models;

namespace WebDevHomework.Interfaces
{
    public interface ILinkWriter
    {
        void Delete(int id);
        Link Create(Link link);
        Link Update(Link link);
    }
}