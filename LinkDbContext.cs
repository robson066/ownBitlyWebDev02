using Microsoft.EntityFrameworkCore;
using WebDevHomework.Models;

namespace WebDev02_Homework
{
    public class LinkDbContext : DbContext
    {
        public LinkDbContext(DbContextOptions<LinkDbContext> options) : base(options)
        {

        }

        public DbSet<Link> Links { get; set; }
    }
}