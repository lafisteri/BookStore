using Core.Models;

namespace DataLayer.BooksRepository;

public interface IBooksRepository
{
    Task<List<Book>> GetAsync();

}
