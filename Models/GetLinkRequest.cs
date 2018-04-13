namespace WebDev02_Homework.Models
{
    public class GetLinkRequest
    {
        public string Search { get; set; }
        public int? Page { get; set; } = 1;
    }
}