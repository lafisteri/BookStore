using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace DataLayer.Context;

public class MySqlContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

}
