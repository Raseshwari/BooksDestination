using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksDestination.Model;

namespace BooksDestination.Services
{
    public class InMemoryBookRepo : IBookData
    {
        private List<BookRepo> _books;

        public InMemoryBookRepo()
        {
            _books = new List<BookRepo> {
                new BookRepo{ BookId = 45, Name = "Prisoner of Birth"},
                new BookRepo{ BookId = 66, Name = "Kite Runner"},
                new BookRepo{ BookId = 78, Name = "Thousand Splendid Suns"}
            };

        }

        public BookRepo AddBook(BookRepo book)
        {
            book.BookId = _books.Max(b => b.BookId) + 1;
            _books.Add(book);
            return book;
        }

        public IEnumerable<BookRepo> GetAll()
        {
            return _books.OrderBy(b => b.Name);
        }

        public BookRepo GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.BookId == id);
        }


    }
}
