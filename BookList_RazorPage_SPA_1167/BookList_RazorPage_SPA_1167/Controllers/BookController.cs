using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookList_RazorPage_SPA_1167;
using BookList_RazorPage_SPA_1167.Data;

namespace BookList_RazorPage_SPA_1167.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        private object book;

        public BookController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _context.Books.ToList() });
        }
        //  [HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    var bookInDb = _context.Books.Find(id);
        //    if (bookInDb == null)
        //        return Json(new
        //        {
        //            success = false,
        //            message =
        //     "Something want wrong while delete date!!!"
        //        });
        //    _context.Books.Remove(bookInDb);
        //    _context.SaveChanges();
        //    return Json(new
        //    {
        //        success = true,
        //        message = "data delete successfuly !!!"
        //    });
        //}


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var bookInDb = _context.Books.Find(id);
            if (bookInDb == null)
                return Json(new
                {
                    success = false,
                    message = "Something went wrong while deleting the data!"
                });

            _context.Books.Remove(bookInDb);
            _context.SaveChanges();

            return Json(new
            {
                success = true,
                message = "Data deleted successfully!"
            });
        }

    }
}
