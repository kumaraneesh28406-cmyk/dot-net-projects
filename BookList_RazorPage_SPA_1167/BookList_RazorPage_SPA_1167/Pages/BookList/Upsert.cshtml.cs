using Booklist_RazorPage_spa_1161.Models;
using BookList_RazorPage_SPA_1167.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BookList_RazorPage_SPA_1167.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public UpsertModel(ApplicationDbContext context)
        {
            _context = context;
        }
        //[BindProperty]
        public Book Book { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();
            if(id == null) return Page(); // Create  
                                           // Edit  
            Book = await _context.Books.FindAsync(id.GetValueOrDefault());
            if (Book == null) return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Book book)
        {
            if (book == null) return BadRequest();

            if (!ModelState.IsValid) return Page();
            

            if (book.Id == 0) 
                await _context.Books.AddAsync(book);
            
            else
            {
                _context.Books.Update(book);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }


    }
}

