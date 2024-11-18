using AutoMapper;
using BusinessLayer.DTO;
using Core.Models;
using DataLayer.BooksRepository;

namespace BusinessLayer.BooksService;

public class BooksService : IBooksService
{
    IBooksRepository _booksRepository;
    IMapper _mapper;

    public BooksService(IBooksRepository booksRepository, IMapper mapper)
    {
        _booksRepository = booksRepository;
        _mapper = mapper;
    }

    public async Task<Book> Get(int? id)
    {
        return await _booksRepository.GetAsync(id);
    }

    public async Task<IEnumerable<Book>> GetAll()
    {
        return await _booksRepository.GetAllAsync();
    }

    public async Task<int> Create(BookDTO bookDTO)
    {
        var book = _mapper.Map<Book>(bookDTO);

        if (book != null)
        {
            return await _booksRepository.CreateAsync(book);
        }

        return 0;
    }

    public async Task<Book> Update(int id, BookDTO bookDTO)
    {
        var item = _mapper.Map<Book>(bookDTO);
        if (item != null)
        {
            item.Id = id;
            return await _booksRepository.UpdateAsync(item);
        }

        return null;
    }

    public async Task<Book> Delete(int id)
    {
        return await _booksRepository.DeleteAsync(id);
    }
}
