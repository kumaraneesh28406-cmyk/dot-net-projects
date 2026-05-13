using Booklist_RazorPage_spa_1161.Models;
using BookList_RazorPage_SPA_1167.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookList_RazorPage_SPA_1167.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> Books1 { get; set; }
        //public object Books { get; private set; }

        public async Task OnGet()
        {
            Books1 = await _context.Books.ToListAsync();
        }
        public async Task<IActionResult>OnPostDelete(int id)
        {
            var bookInDb = await _context.Books.FindAsync(id);
            if (bookInDb == null) return NotFound();
            _context.Books.Remove(bookInDb);
           await _context.SaveChangesAsync();
            return RedirectToAction("Index");
                 }
    }
}
