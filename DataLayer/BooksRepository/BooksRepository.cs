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

    public async Task<List<Book>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book> GetAsync(int? id)
    {
        if (id != null)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }

        return null;
    }

    public async Task<int> CreateAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        return await _context.SaveChangesAsync();
    }

    public async Task<Book> UpdateAsync(Book book)
    {
        _context.Attach(book);
        _context.Entry(book).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return book;
    }

    public async Task<Book> DeleteAsync(int id)
    {
        var entity = await GetAsync(id);
        if (entity != null)
        {
            _context.Books.Remove(entity);
            await _context.SaveChangesAsync();
        }

        return entity;
    }
}
