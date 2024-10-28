using BusinessLayer.BooksService;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly IBooksService _booksService;

        public BooksController(IBooksService bookService)
        {
            _booksService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GET()
        {
            var books = await _booksService.GetAllBooks();

            return Ok(books);
        }
    }
}
