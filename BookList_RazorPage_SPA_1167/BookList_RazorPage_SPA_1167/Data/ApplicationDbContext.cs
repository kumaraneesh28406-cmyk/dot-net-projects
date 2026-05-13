using Booklist_RazorPage_spa_1161.Models;
using Microsoft.EntityFrameworkCore;

namespace BookList_RazorPage_SPA_1167.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>Options) : base(Options)
        {

        }
        public DbSet<Book> Books { get; set; }
        






        //public object BooK { get; internal set; }
    }
}