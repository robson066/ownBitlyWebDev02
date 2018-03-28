using WebDevHomework.Models;

namespace WebDev02_Homework.Models
{
    public class CreateLinkRequest
    {
        public string Title { get; set; }
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }

       public Link GetLink()
       {
           var link = new Link
           {
               Title = this.Title,
               FullUrl = this.FullUrl,
               ShortUrl = this.ShortUrl,

           };

           return link;
       }
    }
}