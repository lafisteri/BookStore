using Core.Models;

namespace DataLayer.BooksRepository;

public interface IBooksRepository
{
    Task<List<Book>> GetAllAsync();
    Task<Book> GetAsync(int? id);
    Task<int> CreateAsync(Book book);
    Task<Book> UpdateAsync(Book book);
    Task<Book> DeleteAsync(int id);
}
