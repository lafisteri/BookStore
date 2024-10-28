using Core.Models;
using DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.BooksRepository;

public class BooksRepository : IBooksRepository
{
    private readonly MySqlContext _context;

    public BooksRepository(MySqlContext context)
    {
        _context = context;
    }
    public async Task<List<Book>> GetAsync()
    {
        return await _context.Books.ToListAsync();
    }
}
