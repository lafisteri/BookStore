using Core.Models;
using DataLayer.BooksRepository;

namespace BusinessLayer.BooksService;

public class BooksService : IBooksService
{
    IBooksRepository _booksRepository;

    public BooksService(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    public async Task<IEnumerable<Book>> GetAllBooks()
    {
        return await _booksRepository.GetAsync();
    }
}
