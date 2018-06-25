using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksDestination.Data;
using BooksDestination.Model;

namespace BooksDestination.Services
{
    public class SqlBookData : IBookData
    {
        private BooksDestinationDbContext _context;

        public SqlBookData(BooksDestinationDbContext context)
        {
            _context = context;
        }
        public BookRepo AddBook(BookRepo book)
        {
            _context.BookRepo.Add(book);
            _context.SaveChanges();
            return book;
        }

        public IEnumerable<BookRepo> GetAll()
        {
            return _context.BookRepo.OrderBy(b => b.BookId);
        }

        public BookRepo GetBookById(int id)
        {
            return _context.BookRepo.FirstOrDefault(b => b.BookId == id);
        }
    }
}
