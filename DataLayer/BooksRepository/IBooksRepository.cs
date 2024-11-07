using Core.Models;

namespace DataLayer.BooksRepository;

public interface IBooksRepository
{
    Task<List<Book>> GetAsync();

    Task<int> CreateAsync(Book book);

}
