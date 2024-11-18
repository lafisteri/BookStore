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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            var item = await _booksService.Get(id);

            return Ok(item);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _booksService.GetAll();

            return Ok(items);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookDTO bookDTO)
        {
            var id = await _booksService.Create(bookDTO);

            if (id != 0)
            {
                return Ok(id);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BookDTO bookDTO)
        {
            var item = await _booksService.Update(id, bookDTO);

            if (item != null)
            {
                return Ok(item);
            }

            return BadRequest($"Item with id {id} was not updated!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _booksService.Delete(id);

            if (item != null)
            {
                return Ok(item);
            }

            return BadRequest($"Item with id {id} was not deleted!");
        }
    }
}
