using System.ComponentModel.DataAnnotations;

namespace WebDevHomework.Models
{
    public class Link
    {
        // Id used for creating hash for shortened link
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string FullUrl { get; set; }
        public string ShortUrl { get; set; }
    }
}