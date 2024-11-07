using BusinessLayer.DTO;
using Core.Models;

namespace BusinessLayer.BooksService;

public interface IBooksService
{
    Task<IEnumerable<Book>> GetAllBooks();

    Task<int> AddBook(BookDTO bookDTO);
}
