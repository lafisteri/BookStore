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

    public async Task<IEnumerable<Book>> GetAllBooks()
    {
        return await _booksRepository.GetAsync();
    }

    public async Task<int> AddBook(BookDTO bookDTO)
    {
        var book = _mapper.Map<Book>(bookDTO);

        if (book != null)
        {
            return await _booksRepository.CreateAsync(book);
        }

        return 0;
    }
}
