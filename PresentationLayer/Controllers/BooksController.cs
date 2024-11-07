using BusinessLayer.BooksService;
using BusinessLayer.DTO;
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
        public async Task<IActionResult> Get(int? id)
        {
            var books = await _booksService.GetAllBooks();

            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookDTO bookDTO)
        {
            var id = await _booksService.AddBook(bookDTO);

            if (id != 0)
            {
                return Ok(id);
            }

            return BadRequest();
        }
    }
}
