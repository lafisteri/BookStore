using BusinessLayer.DTO;
using Core.Models;

namespace BusinessLayer.BooksService;

public interface IBooksService
{
    Task<Book> Get(int? id);
    Task<IEnumerable<Book>> GetAll();
    Task<int> Create(BookDTO bookDTO);
    Task<Book> Update(int id, BookDTO bookDTO);
    Task<Book> Delete(int id);
}
